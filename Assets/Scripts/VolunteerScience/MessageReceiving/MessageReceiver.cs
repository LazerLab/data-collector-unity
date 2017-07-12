/*
 * Author(s): Isaiah Mann
 * Description: Receives messages from the Volunteer Science platform
 * Usage: [no notes]
 */

namespace VolunteerScience
{	
	using UnityEngine;

	public class MessageReceiver : Singleton<MessageReceiver>
	{
		// Name of the function in the player scripts to indicate Unity is ready to receive an initialize call
		const string READY_FUNC = "receiverReady";

		protected override void Awake()
		{
			base.Awake();
			// Sends a call outward to indicate the Unity WebGL app is ready to receive the initialize call from the experiment
			Application.ExternalCall(READY_FUNC);
		}
			
		// Meant to be called externally by the page on which the WebGL game is hosted to indicate the experiment has been initialized
		// NOTE: Should not be called internally within Unity
		public void Initialize()
		{
			ExperimentController.Get.Initialize();
		}

	}

}
