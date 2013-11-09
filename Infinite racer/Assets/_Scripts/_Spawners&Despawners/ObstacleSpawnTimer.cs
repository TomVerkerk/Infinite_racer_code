using UnityEngine;
using System.Collections;

public class ObstacleSpawnTimer : MonoBehaviour {
	
	Transform target;
	
	float spawnTimer = 10;
	
	string obstacleName;
	int obstacleNameRandom;
	
	Vector3 randomPos;
	Quaternion randomRot;
	int randomPositions;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag("SpaceShip").transform;
	}
	
	void Update () {
		spawnTimer -= 5 * Time.deltaTime;
		
		if (spawnTimer <= 0)
		{
			#region Random Obstacle
			obstacleNameRandom = Random.Range(0, 8);
			
			switch(obstacleNameRandom)
			{
				case 0:
				obstacleName = "Obstacle1";
				break;
				
				case 1:
				obstacleName = "Obstacle2";
				break;
				
				case 2:
				obstacleName = "Obstacle3";
				break;
				
				case 3:
				obstacleName = "Obstacle4";
				break;
				
				case 4:
				obstacleName = "Obstacle5";
				break;
				
				case 5:
				obstacleName = "Obstacle6";
				break;
				
				case 6:
				obstacleName = "Obstacle7";
				break;
				
				case 7:
				obstacleName = "Obstacle8";
				break;
			}
			#endregion
			
			#region Random Position
			randomPositions = Random.Range(0, 4);
			
			switch(randomPositions)
			{
				case 0:
				//Down
					randomPos = new Vector3(11, -84.5F, target.position.z + 1000);
					randomRot = Quaternion.Euler(0, 0, 0);
				break;
				
				case 1:
				//Right
					randomPos = new Vector3(68, -10F, target.position.z + 1000);
					randomRot = Quaternion.Euler(0, 0, 90);
				break;
				
				case 2:
				//Left
					randomPos = new Vector3(-65, -10F, target.position.z + 1000);
					randomRot = Quaternion.Euler(0, 0, -90);
				break;
				
				case 3:
				//Up
					randomPos = new Vector3(-11, 49F, target.position.z + 1000);
					randomRot = Quaternion.Euler(0, 0, -180);
				break;
			}
			#endregion
			
			Instantiate(Resources.Load("_Obstacles/" + obstacleName), randomPos, randomRot);
			spawnTimer = 10;	
		}
	}
}
