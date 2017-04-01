/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSDataCollector;

public class DataToStringTest : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
	{
		DataCollector data = DataCollector.Get;
		Experiment exp = data.TrackExperiment("testExperiment");
        exp.AddDataRow(1, 3, "test", 4, 4.5f);
        Debug.Log(exp.LastRowToString());
	}

}
