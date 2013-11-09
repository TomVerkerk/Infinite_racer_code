using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	float range;
	int score;
	public static int HighScore = 0;
	
	void Start () {
		range = 0;
	}
	
	void Update () {
		if (!ShipCollision.death)
		{
			range += 10 * Time.deltaTime;
		}
		
		score = Mathf.RoundToInt(range);
		
		if (score > HighScore)
			HighScore = score;
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(20, 20, 100, 20), "Score : " + score.ToString());	
		
		GUI.Box(new Rect(20, 60, 100, 20), "HighScore : " + HighScore.ToString());
	}
}
