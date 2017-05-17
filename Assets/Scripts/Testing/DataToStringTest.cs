/*
 * Author(s): Isaiah Mann
 * Description: Tests converting a data row to a string
 * Usage: [no notes]
 */

using UnityEngine;
using VolunteerScience;

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
