/*
 * Author(s): Isaiah Mann
 * Description: Used to simulate loading images from Volunteer Science
 * Usage: [no notes]
 */

namespace VolunteerScience
{
	using System;
	using System.Collections.Generic;

	using UnityEngine;

	public class SpriteStoreSimulator : Singleton<SpriteStoreSimulator>
	{
		// Custom Unity field to allow sprites to be assigned in the inspector
		[SerializeField]
		Sprite[] sprites;

		Dictionary<string, Sprite> spriteLookup;

		// Searches for a sprite with a matching filename (NOTE: Unity sprites do not use file extensions)
		public void LoadImage(string fileName, Action<Sprite> callback)
		{
			Sprite sprite;
			if(spriteLookup.TryGetValue(fileName, out sprite))
			{
				// Runs the associated callback if the sprite is found
				callback(sprite);
			}
			else
			{
				Debug.LogErrorFormat("Sprite {0} could not be found", fileName);
			}
		}

		#region Singleton Overrides

		protected override void Awake()
		{
			base.Awake();
			// Generates the Dictionary of sprites upon initialization
			initSpriteLookup();
		}

		#endregion

		void initSpriteLookup()
		{
			spriteLookup = new Dictionary<string, Sprite>();
			foreach(Sprite sprite in sprites)
			{
				spriteLookup[sprite.name] = sprite;
			}
		}

	}

}
