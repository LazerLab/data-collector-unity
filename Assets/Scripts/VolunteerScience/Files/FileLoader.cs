/*
 * Author(s): Isaiah Mann
 * Description: Loading files
 * Usage: [no notes]
 */

namespace VolunteerScience
{
	using System;
	using System.Collections;

	using UnityEngine;

	public class FileLoader : Singleton<FileLoader>
	{
		public void LoadImage(string url, Action<Sprite> callback)
		{
			StartCoroutine(loadTexture(url, callback));
		}

		IEnumerator loadTexture(string url, Action<Sprite> callback)
		{
			Texture2D texture;
			texture = new Texture2D(4, 4, TextureFormat.DXT1, false);
			WWW webRequest = new WWW(url);
			yield return webRequest;
			webRequest.LoadImageIntoTexture(texture);
			Rect textureRect = new Rect(0, 0, texture.width, texture.height);
			Sprite sprite = Sprite.Create(texture, textureRect, textureRect.center);
			callback(sprite);
		}

	}

}