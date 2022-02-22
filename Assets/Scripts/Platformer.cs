using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

    Rigidbody rb;

	//player control variables
	public bool Enabled = true;
    public float speed;
    public float jumpForce;
	public float doubleJumpForce;	//variable for the jumpforce of double jumps
	float x;


	//variables for checking if the player is grounded
	public LayerMask groundlayer;
	public float DistanceToTheGround;
	public bool isGrounded;

	//jumping variables
	public float rememberGroundedFor; 
	float lastTimeGrounded;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	//double jumping variables
	public int defaultAdditionalJumps = 1; 
	int additionalJumps;

	//death variables
	public int deathLayer;
	public int deathCount;
	public bool dead;

	//Checkpoint teleport offsets
	public float xVal = 0.0f;
	public float yVal = 0.0f;
	public float zVal = 0.0f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		PlayerAnimation ();
		if (Enabled) {
			Move ();
			PlayerAnimation ();
			Jump ();
			BetterJump ();
			CheckIfGrounded ();
			if (Input.GetKeyDown (KeyCode.R)) {
				death ();
			}
		}
    }

	//this function controls the player's movement
    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
		var rotationVector = transform.rotation.eulerAngles;	//variable for turning the player when they press a direction
		if (x == 1) {			//right
			rotationVector.y = 110;
			transform.rotation = Quaternion.Euler(rotationVector);
		} else if (x == -1) {	//left
			rotationVector.y = 220;
			transform.rotation = Quaternion.Euler(rotationVector);
		}
    }

	//This function controls jumping and double jumping
	void Jump() {
		if (Input.GetKeyDown (KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
		} 
		//double jumps
		else if((additionalJumps > 0) && (Input.GetKeyDown (KeyCode.Space))) {
			rb.velocity = new Vector2 (rb.velocity.x, doubleJumpForce);
			additionalJumps--;
		}
	}

	//This function makes jumping feel smoother and allows you to just tap the jump button for a short jump
	void BetterJump() {
		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}	
	}

	//This function checks if the player is on the ground
	void CheckIfGrounded()
	{
		DistanceToTheGround = GetComponent<Collider>().bounds.extents.y;
		isGrounded = Physics.Raycast(transform.position, Vector3.down, DistanceToTheGround + 0.1f, groundlayer);
		if (isGrounded) {
			lastTimeGrounded = Time.time;
			additionalJumps = defaultAdditionalJumps;
		}
	}

	//this function teleports the player to the last checkpoint they touched
	void moveToCheck() {
		GameObject checkpoint = GameObject.Find("CheckpointManager").GetComponent<CheckManager>().getCheckpoint(); //gets the current checkpoint gameobject
		GameObject.Find("Player").transform.position = new Vector3(checkpoint.transform.position.x + xVal, checkpoint.transform.position.y + yVal, checkpoint.transform.position.z + zVal);
	}

	//this function is for when the player dies
	void death() {
		GameObject[] EnemyList = GameObject.FindGameObjectsWithTag ("enemy");
		for (int i = 0; i < EnemyList.Length; i++) {
			EnemyList [i].GetComponent<EnemyRespawn> ().ResetPosition ();
		}


		moveToCheck ();
		deathCount++;
		dead = false;
	}

	//detects collisions
	void OnCollisionEnter(Collision Collider) {

		//if the player collides with an object on the death layer, activate the death function
		if ((Collider.gameObject.layer == deathLayer) && Enabled) {
			dead = true;
			death ();
			Debug.Log("died");

		}
	}

	//this function allows other scripts to move the player
	public void movePlayer (float xVelocity, float yVelocity) {
		//if (xVelocity == 0) {
			//xVelocity = rb.velocity.x;
		//}
		if (yVelocity == 0) {
			yVelocity = rb.velocity.y;
		}
		rb.velocity = new Vector2 (xVelocity, yVelocity);
	}

	//this function controls the player's animations
	private void PlayerAnimation () {
		if (isGrounded && (x == 1 || x == -1)) {
			this.GetComponent<Animator> ().SetInteger ("Mode", 1);
			Debug.Log (x);
		} else {
			this.GetComponent<Animator> ().SetInteger ("Mode", 0);
		}
	}

}