/**
 * @author: Isaiah Mann
 * @desc: Used to communicate between Unity iFrame and Volunteer Science host page (host-side)
 * @requires: vs-unity-globals.js, iFrame should have id of "game"
 */

// A reference to the iFrame in which the Unity WebGL player is embedded
var gameWindow;

// Handles a message passed to the page with the postMessage function
function receiveEvent(event)
{
     if(isFetchEvent(event.data))
     {
          handleFetchEvent(event.data);
     }
     else if(isSubmitEvent(event.data))
     {
          handleSubmitEvent(event.data);
     }
     else if(isCompleteEvent(event.data))
     {
          experimentComplete();
     }
     else if(isSetEvent(event.data))
     {
          handleSetEvent(event);
     }
     else if(isSetConsumablesEvent(event.data))
     {
          handleSetConsumablesEvent(event.data);
     }
}

// Used for events sent from the Unity Player to set a variable in Volunteer Science
function handleSetEvent(event)
{
     if(isRoundEvent(event.data))
     {
          trySetRound(event);
     }
}

// Attempts to set the round of the experiment
function trySetRound(event)
{
     // Expects the third part of the message to be the new integer
     var roundIdStr = event.data.split(JOIN_CHAR)[2];
     // Returns true if the round was successfully set
     try
     {
          var roundId = parseInt(roundIdStr);
          setRound(roundId);
          return true;
     }
     catch(e)
     {
          console.error(e + "Unable to parse " + roundIdStr + " to integer");
          return false;
     }
}

// Fetch events are cases in which the Unity player is requested information from Volunteer Science
function handleFetchEvent(eventData)
{
     // The data returned is based on the key associated with the request
     var args = eventData.split(JOIN_CHAR);
     var dataKey = args[1];
     var dataID = args[2];
     var value;
     // Checks for specific experiment parameter keys
     if(isRoundEvent(dataKey))
     {
          value = currentRound;
     }
     else if(isPlayerIDEvent(dataKey))
     {
          value = myid;
     }
     else if(isPlayerNameEvent(dataKey))
     {
          value = getPlayerName(eventData);
     }
     else if(isPlayerCountEvent(dataKey))
     {
          value = numPlayers;
     }
     else if(isSeedEvent(dataKey))
     {
          value = seed;
     }
     else if(isGetConsumablesEvent(dataKey))
     {
          // Terminate function early, this fetch requires a callback
          fetchConsumables(eventData);
       	  return;
     }
     else if(isMatrixEvent(dataKey))
     {
          value = fetchMatrixValue(eventData);
     }
     else
     {
          // If the key is not a special experiment variable, get the value from custom experiment variables dictionary:
          value = variables[dataKey];
     }
     if(value != null)
     {
          // Wildcard value for source (*)
          // Sends the key and corresponding value back to the Unity Player
          sendDataToGame(dataKey, dataID, value);
     }
}

function sendDataToGame(dataKey, dataID, value)
{
 	gameWindow.postMessage(FETCH_KEY + JOIN_CHAR + dataKey + JOIN_CHAR + dataID + JOIN_CHAR + value, "*");
}

function getPlayerName(playerNameKey)
{
     var playerID = playerNameKey.split(JOIN_CHAR)[3];
     var playerName;
     try
     {
          playerName = getName(parseInt(playerID));
     }
     catch(e)
     {
          console.error(e + "unable to parse player ID" + playerID + " to integer. Returning empty string for player name");
          playerName = "";
     }
     return playerName;
}

// Used to send data to Volunteer Science via a submit call
function handleSubmitEvent(eventData)
{
     submit(eventData.split(JOIN_CHAR)[1]);
}

// Used to get a value from a matrix
function fetchMatrixValue(eventData)
{
     // Expected format: [fetch:<id>:vs_matrix:<matrix>:<row>:<column>]
     var arguments = parseArguments(eventData);
     var matrix = arguments[3];
     try
     {
          // Row and column values are zero-indexed
          var row = parseInt(arguments[4]);
          var column = parseInt(arguments[5]);
          // Uses the volunteer science call to access the desired matrix:
          return getMatrixValue(matrix, row, column);
     }
     catch(e)
     {
          console.error(e + "Unable to parse matrix info from " + arguments + ". Returning null.")
          return null;
     }
}

// Fetches list of consumables from an event key
function fetchConsumables(eventData)
{
	 // Expected format: [fetch:<id>:vs_consumables:<class>:<set>:<amount>]
     var arguments = eventData.split(JOIN_CHAR);
     var dataKey = arguments[1];
     var dataID = arguments[2];
     try
     {
          var amount = parseInt(arguments[5]);
          getConsumables(arguments[3], arguments[4], amount,
                         function(data, err)
                         {
			               sendDataToGame(dataKey, dataID, data);
     				}
          );
     }
     catch(e)
     {
          console.error("Unable to parse amount from " + arguments[3] + ". Unable to get consumable");
     }
}

// Sets a consumable to used
function handleSetConsumablesEvent(eventData)
{
     // Expected format: [vs_set_consumables:<class>:<set>:<choice>]
     var arguments = parseArguments(eventData);
     setConsumables(arguments[1], arguments[2], arguments[3]);
}

// Assigns the iFrame to a variable
function setGameWindow()
{
     gameWindow = document.getElementById("game").contentWindow;
}

// Called by Volunteer Science. Sends a message to Unity to run the contained Initialize() function
// This function can be subscribed to within Unity, to run callbacks when it receives this message
function initialize()
{
     gameWindow.postMessage(INIT_KEY, "*");
}

// Wait until the page loads to set the reference to the iFrame
window.onload = setGameWindow;

// Subscribe the event handler for when the page receives a message via postMessage()
window.addEventListener('message', receiveEvent, false);
