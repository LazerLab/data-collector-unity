/*
 * Author(s): Isaiah Mann
 * Description: Tests the timer function in the Experiment class
 * Usage: [no notes]
 */

using System.Collections;
using UnityEngine;
using VolunteerScience;

public class TimerTest : MonoBehaviour 
{
    [SerializeField]
    float testWaitTime = 2.34232f;

	// Use this for initialization
	void Start() 
	{
        DataCollector data = DataCollector.Get;
        Experiment exp = data.TrackExperiment("testExperiment");	
        StartCoroutine(timerTest(exp));
	}

    IEnumerator timerTest(Experiment exp)
    {
        string reactionTime = "reaction";
        exp.TimeEvent(reactionTime);
        yield return new WaitForSeconds(testWaitTime);
        double ellapsedTime = exp.GetEventTimeSeconds(reactionTime);
        Debug.Log(ellapsedTime);
    }
        
}
