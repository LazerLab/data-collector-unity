/*
 * Author(s): Isaiah Mann
 * Description: Tests the image loading capabilities
 * Usage: [no notes]
 */

using UnityEngine;
using UnityEngine.UI;

using VolunteerScience;

public class ImageLoadingTest : MonoBehaviour 
{
	[SerializeField]
	string imageURL;
	[SerializeField]
	Image image;

	// Use this for initialization
	void Start() 
	{
		FileLoader files = FileLoader.Get;
		files.LoadImage(imageURL, setImage);
	}

	void setImage(Sprite Sprite)
	{
		image.sprite = Sprite;
	}

}
