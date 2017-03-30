/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSDataCollector;

public class SingletonTest : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
	{
		DataCollector collector = DataCollector.Get;
	}

}
