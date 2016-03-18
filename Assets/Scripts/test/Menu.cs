using UnityEngine;
using System.Collections;
using System.IO;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
	// VIEW

	void Start ()
	{
		GameObject c = UIFactory.CreateCanvas (this.transform);
		GameObject p = UIFactory.CreatePanel (c.transform);
		UIFactory.CreateText (p.transform, 0, 100, 160, 50, "Tests", 32);
		UIFactory.CreateText (p.transform, 0, 0, 160, 50, "Choose a demo", 24);
		UIFactory.CreateButton (p.transform, 0, -100, 300, 70, "Quit", delegate {
			quit ();
		});
		UIFactory.CreateButton (p.transform, 0, -200, 300, 70, "Editor", delegate {
			editor ();
		});
		UIFactory.CreateButton (p.transform, 0, -300, 300, 70, "Map", delegate {

		});

	}

	// PRESENTER

	void quit ()
	{
		// TODO use Destroy(this)
		Destroy (GameObject.Find ("Menu"));
		new GameObject ("Quit").AddComponent<Quit> ();
	}

	void editor ()
	{
		// TODO use Destroy(this)
		Destroy (GameObject.Find ("Menu"));
		new GameObject ("Editor").AddComponent<Editor> ();
	}

	// TRANSITION

	// http://docs.unity3d.com/Manual/HOWTO-UIScreenTransition.html



	/*
	// https://unity3d.com/learn/tutorials/projects/stealth/screen-fader

	// Speed that the screen fades to and from black.
	public float fadeSpeed = 1.5f;
	// Whether or not the scene is still fading in.
	private bool sceneStarting = true;

	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	void Update ()
	{
		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if(guiTexture.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}
	}

	public void EndScene ()
	{
		// Make sure the texture is enabled.
		guiTexture.enabled = true;

		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if(guiTexture.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel(0);
	}
	*/
}
