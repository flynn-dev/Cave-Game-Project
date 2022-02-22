using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

    Rigidbody rb;

	//player control variables
    public float speed;
    public float jumpForce;
	public float doubleJumpForce;	//variable for the jumpforce of double jumps

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
		BetterJump ();
        CheckIfGrounded();
    }

	//this function controls the player's movement
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
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
}