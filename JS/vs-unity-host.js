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
}

function handleFetchEvent(eventData)
{
     // Get the key
     var dataKey = eventData.split(JOIN_CHAR)[1];
     var value = variables[dataKey];
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
