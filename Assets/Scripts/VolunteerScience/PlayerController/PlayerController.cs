/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

namespace VolunteerScience
{
	using System;
	using System.Collections;

	public class PlayerController : Singleton<PlayerController>
	{
		const string PLAYER_ID_KEY = "vs_player_id";
		const string PLAYER_NAME_KEY = "vs_player_name";
		const string PLAYER_COUNT_KEY = "vs_num_players";

		public IntFetchAction GetPlayerCount(Action<int> callback)
		{
			return VariableFetcher.Get.GetInt(PLAYER_COUNT_KEY, callback);
		}

		public IntFetchAction GetMyID(Action<int> callback)
		{
			return VariableFetcher.Get.GetInt(PLAYER_ID_KEY, callback);
		}
			
		// Gets the name for the current player
		public void GetName(Action<string> callback)
		{
			GetMyID(
				delegate(int playerId)
				{
					GetName(playerId, callback);
				}
			);
		}

		public StringFetchAction GetName(int playerID, Action<string> callback)
		{
			return VariableFetcher.Get.GetString(getPlayerNameKey(playerID), callback);
		}

		string getPlayerNameKey(int playerID)
		{
			return VariableFetcher.Get.FormatFetchCall(PLAYER_NAME_KEY, playerID.ToString());
		}

	}

}
