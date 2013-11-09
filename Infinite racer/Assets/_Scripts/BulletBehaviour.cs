using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	float speed = 4000;
	float range = 10;
	float bullet = 0;
	
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		bullet += 10 * Time.deltaTime;
		if (bullet > range)
		{
			Destroy(gameObject);	
		}
	}
}
