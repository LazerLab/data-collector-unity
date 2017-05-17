/*
 * Author(s): Isaiah Mann
 * Description: Verifies calling the Get accessor creates a singleton
 * Usage: [no notes]
 */

using UnityEngine;
using VolunteerScience;

public class SingletonTest : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
	{
		DataCollector collector = DataCollector.Get;
	}

}
