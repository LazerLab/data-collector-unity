/*
 * Author(s): Isaiah Mann
 * Description: Singleton Class to store collected data
 * Usage: [no notes]
 */

using UnityEngine;
using System.Collections.Generic;
using fJSON = fastJSON;
using sJSON = SimpleJSON;

namespace VSDataCollector
{	
	public class DataCollector : Singleton<DataCollector>
	{
		Dictionary<string, Experiment> instances = new Dictionary<string, Experiment>();

		public Experiment TrackExperiment(string instanceName)
		{
			Experiment exp = new Experiment(instanceName);
			instances[exp.GetName] = exp;
			return exp;
		}

		public Experiment GetExperiment(string name)
		{
			Experiment exp;
			if(instances.TryGetValue(name, out exp))
			{
				return exp;
			}
			else
			{
				return TrackExperiment(name);
			}
		}

	}

	[System.Serializable]
	public class Experiment
	{
		public string GetName
		{
			get
			{
				return this.experimentName;
			}
		}
			
		public string experimentName;
		public Dictionary<string, object> data;

		public Experiment(string name)
		{
			this.experimentName = name;
			this.data = new Dictionary<string, object>();
		}

		public void SetDelegate(string key, object value)
		{
			this.data[key] = value;
		}

		// Returns the data as a string
		public string ToJSON()
		{
			string fullObjJSON = fJSON.JSON.ToJSON(this);
			sJSON.JSONNode dataJSON = sJSON.JSON.Parse(fullObjJSON)["data"];
			return dataJSON.ToString();
		}

	}

}
