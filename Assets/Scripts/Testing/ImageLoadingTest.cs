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
	string imageName;
	[SerializeField]
	Image image;

	// Use this for initialization
	void Start() 
	{
		FileLoader files = FileLoader.Get;
		files.LoadImage(imageName, setImage);
	}

	void setImage(Sprite Sprite)
	{
		image.sprite = Sprite;
	}

}
