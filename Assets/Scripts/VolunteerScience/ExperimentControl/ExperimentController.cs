/*
 * Author(s): Isaiah Mann
 * Description: Controls the overall flow and logic of experiments
 * Usage: [no notes]
 */

namespace VolunteerScience
{
    using System;

    using UnityEngine;

    public class ExperimentController : Singleton<ExperimentController>
    {
        const string COMPLETE_EXPERIMENT_FUNC = "completeExperiment";
		const string SET_ROUND_FUNC = "setRound";
        const string ROUND_KEY = "vs_round";
		const string SEED_KEY = "vs_seed";

        public void CompleteExperiment()
        {
            Application.ExternalCall(COMPLETE_EXPERIMENT_FUNC);
        }

		public void SetRound(int roundId)
		{
			Application.ExternalCall(SET_ROUND_FUNC, roundId);
		}

        public IntFetchAction GetRound(Action<int> callback)
        {
            return VariableFetcher.Get.GetInt(ROUND_KEY, callback);
        }

		public IntFetchAction GetSeed(Action<int> callback)
		{
			return VariableFetcher.Get.GetInt(SEED_KEY, callback);
		}

    }

}
