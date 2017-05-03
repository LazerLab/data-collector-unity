/**
 * @author: Isaiah Mann
 * @desc: Used to communicate between Unity iFrame and Volunteer Science host page (host-side)
 * @requires: vs-unity-globals.js, iFrame should have id of "game"
 */

var gameWindow;

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
}

function handleSetEvent(event)
{
     if(isRoundEvent(event.data))
     {
          trySetRound(event);
     }
}

function trySetRound(event)
{
     var roundIdStr = event.data.split(JOIN_CHAR)[2];
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

function handleFetchEvent(eventData)
{
     // Get the key
     var dataKey = eventData.split(JOIN_CHAR)[1];
     var value;
     if(dataKey == ROUND_KEY)
     {
          value = currentRound;
     }
     else
     {
          value = variables[dataKey];
     }
     // Wildcard value for source:
     gameWindow.postMessage(FETCH_KEY + JOIN_CHAR + dataKey + JOIN_CHAR + value, "*");
}

function handleSubmitEvent(eventData)
{
     submit(eventData.split(JOIN_CHAR)[1]);
}

function setGameWindow()
{
     gameWindow = document.getElementById("game").contentWindow;
}

window.onload = setGameWindow;
window.addEventListener('message', receiveEvent, false);
