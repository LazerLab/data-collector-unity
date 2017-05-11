/**
 * @author: Isaiah Mann
 * @desc: Used to communicate between Unity iFrame and Volunteer Science host page (player-side)
 * @requires: vs-unity-globals.js, both scripts should be added as a script to the index.html of the WebGL build
 */

var MESSAGE_RECEIVER_GAME_OBJECT = "VSReceiver";
var INIT_FUNC = "Initialize";
var RECEIVER_TIME_OUT = 10000; // In milliseconds
var RECEIVER_WAIT_TIME = 100;

var unityFetchCallbacks = {};
var receiverIsReady = false;
var recieverAccessTimer = 0;

class UnityCallback
{
     // Uses the `SendMessage` function in Unity Web GL to call a function on the GameObject by name
     constructor(gameObject, callbackFunction)
     {
         this.gameObject = gameObject;
         this.callbackFunction = callbackFunction;
     }
}

// Event handler for messages sent by the Volunteer Science host
function receiveEvent(event)
{
     if(isFetchEvent(event.data))
     {
          handleFetchEventCallback(event.data);
     }
     else if(isInitEvent(event.data))
     {
          initialize();
     }
}

// Sends requested data back to Unity fomr a fetch call
function handleFetchEventCallback(eventData)
{
     // Should return: ["vs_fetch", key, value]
     var message = eventData.split(JOIN_CHAR);
     var key = message[1];
     var value = message[2];
     var callback = unityFetchCallbacks[key];
     // Unity defined function:
     SendMessage(callback.gameObject, callback.callbackFunction, value);
}

// Sends message to Volunteer Science via "submit" call
function submit(data)
{
     parent.window.postMessage(SUBMIT_KEY + JOIN_CHAR + data, "*");
}

// Retrieves a variable corresponding to a particular key from Volunteer Science
function fetch(key, gameObject, callbackFunction)
{
     unityFetchCallbacks[key] = new UnityCallback(gameObject, callbackFunction);
     parent.window.postMessage(FETCH_KEY + JOIN_CHAR + key, "*");
}

// To be called when the player completes an experiment in Volunteer Science
function completeExperiment()
{
     parent.window.postMessage(COMPLETE_KEY, "*");
}

function setRound(roundId)
{
     parent.window.postMessage(SET_KEY + JOIN_CHAR + ROUND_KEY + JOIN_CHAR + roundId, "*");
}

function initialize()
{
     if(recieverAccessTimer < RECEIVER_TIME_OUT)
     {
          if(receiverIsReady)
          {
               SendMessage(MESSAGE_RECEIVER_GAME_OBJECT, INIT_FUNC);
          }
          else
          {
               window.setTimeout(initialize, RECEIVER_WAIT_TIME);
               recieverAccessTimer += RECEIVER_WAIT_TIME;
          }
     }
}

function receiverReady()
{
     receiverIsReady = true;
}

window.addEventListener("message", receiveEvent, false);
