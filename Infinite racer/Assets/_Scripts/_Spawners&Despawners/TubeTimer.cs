using UnityEngine;
using System.Collections;

public class TubeTimer : MonoBehaviour {

	Transform target;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag("SpaceShip").transform;
	}
	
	void Update () {
		if (transform.position.z < target.position.z - 300)
		{
			Destroy(gameObject);	
		}
	}
}
