/*
 * Author(s): Isaiah Mann
 * Description: Controls the overall flow and logic of experiments
 * Usage: [no notes]
 */

namespace VolunteerScience
{
    using UnityEngine;

    public class ExperimentController : Singleton<ExperimentController>
    {
        const string COMPLETE_EXPERIMENT_FUNC = "completeExperiment";

        public void CompleteExperiment()
        {
            Application.ExternalCall(COMPLETE_EXPERIMENT_FUNC);
        }

    }

}
