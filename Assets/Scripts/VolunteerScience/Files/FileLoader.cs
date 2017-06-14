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
		const string FILE_URL_KEY = "vs_file_url";

		public void LoadImage(string fileName, Action<Sprite> callback)
		{
			GetFileURL(fileName, delegate(string fileURL)
				{
					StartCoroutine(loadTexture(fileURL, callback));
				});
		}

		public StringFetchAction GetFileURL(string fileName, Action<string> callback)
		{
			return VariableFetcher.Get.GetString(getFileURLFetchCallback(fileName), callback);
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

		string getFileURLFetchCallback(string fileName)
		{
			return VariableFetcher.Get.FormatFetchCall(FILE_URL_KEY, fileName);
		}

	}

}
