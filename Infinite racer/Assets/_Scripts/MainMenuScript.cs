using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(100, 100, 150, 100), "Use TrackIR"))
		{
			FlightMovement.startRun = true;
		}
		if (GUI.Button(new Rect(Screen.width - 250, 100, 150, 100), "Use Mouse"))
		{
			FlightMovement.startRun = false;
		}
		
		if (GUI.Button(new Rect((Screen.width / 2) - 75, 100, 150, 100), "Start Game"))
		{
			Application.LoadLevel("Scene1");	
		}
		
		if (GUI.Button(new Rect(100, Screen.height - 250, 150, 100), "Credits Screen"))
		{
			Application.LoadLevel("CreditsScreen");	
		}
	}
}
