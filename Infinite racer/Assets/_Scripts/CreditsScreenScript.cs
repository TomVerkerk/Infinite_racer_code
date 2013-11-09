using UnityEngine;
using System.Collections;

public class CreditsScreenScript : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(100, Screen.height -250, 150, 100), "Back To Main Menu"))
		{
			Application.LoadLevel("MainMenu");	
		}
	}
}
