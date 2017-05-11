/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

namespace VolunteerScience
{
	using System;

	public class PlayerController : Singleton<PlayerController>
	{
		const string PLAYER_ID_KEY = "vs_player_id";

		public IntFetchAction GetMyID(Action<int> callback)
		{
			return VariableFetcher.Get.GetInt(PLAYER_ID_KEY, callback);
		}

	}

}
