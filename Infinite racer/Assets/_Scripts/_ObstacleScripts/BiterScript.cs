using UnityEngine;
using System.Collections;

public class BiterScript : MonoBehaviour {

	Transform up, down;
	
	void Start () {
		up = transform.FindChild("Obstacle1/Obstakel Sluiting Boven");
		down = transform.FindChild("Obstacle1/Obstakel Sluiting Boven 1");
	}
	
	void Update () {	
		up.Rotate(10, 0, 0);
		down.Rotate(-10, 0, 0);
	}
}
