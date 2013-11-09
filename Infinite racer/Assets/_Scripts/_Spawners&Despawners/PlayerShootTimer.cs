using UnityEngine;
using System.Collections;

public class PlayerShootTimer : MonoBehaviour {

	Transform muzzleLeft, muzzleRight;
	
	public float timer = 5;
	
	void Start () {
		muzzleLeft = GameObject.FindGameObjectWithTag("MuzzleLeft").transform;
		muzzleRight = GameObject.FindGameObjectWithTag("MuzzleRight").transform;
	}
	
	void Update () {
		timer -= 10 * Time.deltaTime;
		
		if (timer <= 0)
		{
			//Instantiate(Resources.Load("Bullet"), muzzleLeft.position, muzzleLeft.rotation);
			//Instantiate(Resources.Load("Bullet"), muzzleRight.position, muzzleRight.rotation);
			timer = 5;	
		}
	}
}
