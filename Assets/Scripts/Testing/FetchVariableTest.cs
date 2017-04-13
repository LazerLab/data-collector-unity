/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolunteerScience;

public class FetchVariableTest : MonoBehaviour 
{
    [SerializeField]
    string testKey = "testKey";

	// Use this for initialization
	void Start() 
	{
        VariableFetcher fetcher = VariableFetcher.Get;	
        fetcher.GetValue(testKey, printValue);
	}

    void printValue(object value)
    {
        Debug.Log(value);
    }

}
