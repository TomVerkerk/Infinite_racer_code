using UnityEngine;
using System.Collections;

public class ShipRotateMainMenu : MonoBehaviour {
	
	void Update () {
		transform.Rotate(0, 40 * Time.deltaTime, 0);
	}
}
