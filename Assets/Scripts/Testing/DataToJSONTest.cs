/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSDataCollector;

public class DataToJSONTest : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
	{
		DataCollector data = DataCollector.Get;
		Experiment exp = data.TrackExperiment("testExperiment");
		exp.SetDelegate("Time", 5.0f);
		exp.SetDelegate("Count", 10);
		print(exp.ToJSON());
	}

}
