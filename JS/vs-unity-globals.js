var FETCH_KEY = "vs_fetch";
var SUBMIT_KEY = "vs_submit";
var COMPLETE_KEY = "vs_complete";
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
