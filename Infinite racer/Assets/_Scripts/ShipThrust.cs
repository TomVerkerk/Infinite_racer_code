using UnityEngine;
using System.Collections;

public class ShipThrust : MonoBehaviour {

	CharacterController controller;
	public static float speed = 730F;
	
	public static bool SpeedPowerupUsing = false;
	float speedPowerUpTime = 5;
	
	Vector3 moveDirection = Vector3.zero;
	
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		
		speed = 730F;
	}
	
	void Update () {
		moveDirection = new Vector3(0, 0, 1);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		
		controller.Move(moveDirection * Time.deltaTime);
	}
}
