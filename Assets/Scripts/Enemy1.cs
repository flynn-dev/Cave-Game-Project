using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {
	//0 = nothing, 1 = right, 2 = left
	public int Direction;			//direction the enemy is moving
	public int Speed;				//movement speed of the enemy
	public int ColliderLayer = 11;	//the layer that will cause the enemy to turn around when it collides with it
	Rigidbody rb;

	public int TrackingProximity;	//the proximity to the player the enemy has to be before it starts moving towards the player
	public bool PlayerTracking = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		this.GetComponent<Animator> ().SetBool ("AnimationON", false);

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		//MoveTowardPlayer ();
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector = transform.rotation.eulerAngles;	//variable for turning the player when they press a direction
		if (Direction == 1) {			//right
			rotationVector.y = 0;
			transform.rotation = Quaternion.Euler (rotationVector);
		} else if (Direction == 2) {	//left
			rotationVector.y = 180;
			transform.rotation = Quaternion.Euler (rotationVector);
		}

	}

	void Move () {
		if (Direction == 1) { //right
			rb.velocity = new Vector2 (Speed, rb.velocity.y);
		} else if (Direction == 2) { //left
			rb.velocity = new Vector2 (-Speed, rb.velocity.y);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if ((collider.gameObject.layer == ColliderLayer) /*&& PlayerTracking == false*/) {
			if (Direction == 1) {
				Direction = 2;
			} else if (Direction == 2) {
				Direction = 1;
			}
		}
	}


	/*
	void MoveTowardPlayer() {
		int playerX = (int)GameObject.Find("Player").transform.position.x;
		int enemyX = (int)gameObject.transform.position.x;

		if (((enemyX + TrackingProximity) > playerX) && ((enemyX - TrackingProximity) < playerX)) {
			PlayerTracking = true;
			if (playerX > enemyX) {
				Direction = 1;
			} else if (playerX < enemyX) {
				Direction = 2;
			}
		} else {
			PlayerTracking = false;
		}
	}
	*/



}
