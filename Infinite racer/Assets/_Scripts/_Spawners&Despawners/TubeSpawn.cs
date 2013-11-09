using UnityEngine;
using System.Collections;

public class TubeSpawn : MonoBehaviour {
	
	float tubeSpawnTimer = 5;
	
	int totalTubes = 1;
	
	int texture;
	
	void Start () {
		
	}
	
	void Update () {
		tubeSpawnTimer -= 8.878F * Time.deltaTime;
		
		if (tubeSpawnTimer <= 0)
		{
			GameObject tube = Instantiate(Resources.Load("Tube"), 
				new Vector3(0, -1100, (420 * totalTubes) + 1040), transform.rotation) as GameObject;	
			
			texture = Random.Range(0, 3);
			
			switch(texture)
			{
				case 0:	
				tube.transform.FindChild("Cylinder").renderer.material.mainTexture = Resources.Load("_Textures/texture tube 1") as Texture;
				break;
				
				case 1:
				tube.transform.FindChild("Cylinder").renderer.material.mainTexture = Resources.Load("_Textures/texture tube 2") as Texture;
				break;
				
				case 2:
				tube.transform.FindChild("Cylinder").renderer.material.mainTexture = Resources.Load("_Textures/texture tube 3") as Texture;
				break;
			}
			
			tube.transform.FindChild("Cylinder").renderer.material.SetColor("_Color", Color.red);
			tubeSpawnTimer = 5;
			totalTubes++;
		}
	}
}
