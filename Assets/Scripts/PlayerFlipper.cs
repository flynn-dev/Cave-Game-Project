using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		var rotationVector = transform.rotation.eulerAngles;	//variable for turning the player when they press a direction
		if (x == 1) {			//right
			rotationVector.x = 110;
			transform.rotation = Quaternion.Euler(rotationVector);
		} else if (x == -1) {	//left
			rotationVector.x = -110;
			transform.rotation = Quaternion.Euler(rotationVector);
		}
	}
}
