/*
 * Author(s): Isaiah Mann
 * Description: Receives messages from the Volunteer Science platform
 * Usage: [no notes]
 */

namespace VolunteerScience
{	
	public class MessageReceiver : Singleton<MessageReceiver>
	{
		public void Initialize()
		{
			ExperimentController.Get.Initialize();
		}

	}

}
