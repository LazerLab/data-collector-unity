/**
 * @author: Isaiah Mann
 * @desc: Contains global variables which are used on both the player and host logic for integrating Unity with Volunteer Science
 */

var FETCH_KEY = "vs_fetch";
var SUBMIT_KEY = "vs_submit";
var COMPLETE_KEY = "vs_complete";
var SET_KEY = "vs_set";
var ROUND_KEY = "vs_round";
var ID_KEY = "vs_id";
var JOIN_CHAR = ":";

function isFetchEvent(eventData)
{
     return eventData.includes(FETCH_KEY);
}

function isSubmitEvent(eventData)
{
     return eventData.includes(SUBMIT_KEY);
}

function isCompleteEvent(eventData)
{
	return eventData == COMPLETE_KEY;
}

function isSetEvent(eventData)
{
	return eventData.includes(SET_KEY);
}

function isRoundEvent(eventData)
{
	return eventData.includes(ROUND_KEY);
}
