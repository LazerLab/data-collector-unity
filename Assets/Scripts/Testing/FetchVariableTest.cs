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

    [SerializeField]
    string testInt = "testInt";

    [SerializeField]
    string testFloat = "testFloat";

    [SerializeField]
    string testBool = "testBool";

    [SerializeField]
    string testValueList = "testValueList";

    [SerializeField]
    string testIntList = "testIntList";

    [SerializeField]
    string testBoolList = "testBoolList";

    [SerializeField]
    string testFloatList = "testFloatList";

	// Use this for initialization
	void Start() 
	{
        VariableFetcher fetcher = VariableFetcher.Get;	
        fetcher.GetValue(testKey, printValue);
        fetcher.GetInt(testInt, incremementInt);
        fetcher.GetFloat(testFloat, divideFloat);
        fetcher.GetBool(testBool, invertBool);
        fetcher.GetValueList(testValueList, printList);
        fetcher.GetIntList(testIntList, sumInts);
        fetcher.GetBoolList(testBoolList, andBools);
        fetcher.GetFloatList(testFloatList, sumFloats);
        ExperimentController.Get.GetRound(printRound);
	}

    void printValue(object value)
    {
        Debug.Log(value);
    }

    void incremementInt(int value)
    {
        value++;
        Debug.Log(value);
    }
        
    void divideFloat(float value)
    {
        value /= 2.0f;
        Debug.Log(value);
    }

    void invertBool(bool value)
    {
        value = ! value;
        Debug.Log(value);
    }

    void sumInts(int[] list)
    {
        int sum = 0;
        foreach(int num in list)
        {
            sum += num;
        }
        Debug.Log("The sum is " + sum);
    }

    void sumFloats(float[] list)
    {
        float sum = 0;
        foreach(float num in list)
        {
            sum += num;
        }
        Debug.Log("The sum is " + sum);
    }

    void andBools(bool[] list)
    {
        bool result = true;
        foreach(bool test in list)
        {
            result &= test;
        }
        Debug.Log("The result is " + result);
    }

    void printList(object[] list)
    {
        string toPrint = "[";
        foreach(object obj in list)
        {
            toPrint += string.Format("{0}, ",obj.ToString());
        }
        toPrint = toPrint.TrimEnd(new char[]{',', ' '});
        toPrint += "]";
        Debug.Log(toPrint);
    }

    void printRound(int round)
    {
        Debug.Log("The round is " + round);
    }

}
