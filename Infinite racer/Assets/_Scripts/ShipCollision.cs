using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {

	public static bool death = false;
	
	void Start()
	{
		death = false;
	}
	
	void Update()
	{
		RaycastHit hit;
    	if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.0F)) 
		{
			if (hit.transform.tag == "Obstacle")
			{
				Debug.Log("LOSe");
				ShipThrust.speed = 0;
				death = true;
			}
			
			if (hit.transform.tag == "SpeedPowerup")
			{
				ShipThrust.SpeedPowerupUsing = true;	
			}
    	}
		
		if(death == true)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel("Scene1");	
			}
		}
	}
	
	void OnGUI()
	{		
		if (death)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "PRESS SPACE TO RESTART" +
				"" +
				"" +
				"" +
				"HIGHSCORE =  " + ScoreScript.HighScore);	
		}
	}
}
