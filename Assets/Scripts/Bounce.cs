using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	public float xBounce;	//the force of the bounce in the x direction
	public float yBounce;	//the force of the bounce in the y direction

	private bool down = false;
	public float downTime = 0.4f;
	public float downAmount = 0.8f;
	private float targetTime;

	// Use this for initialization
	void Start () {
		targetTime = downTime;
	}
	
	// Update is called once per frame
	void Update () {

		if (down) {
			targetTime -= Time.deltaTime;
		}

		if (targetTime <= 0.0f) {

			timerEnded ();
		}
	}
	private void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			GameObject.Find("Player").GetComponent<Platformer>().movePlayer(xBounce, yBounce);
			gameObject.transform.localScale = new Vector3(1.0f, downAmount, 1.0f);
			down = true;
		}
	}
		
	void timerEnded (){
		gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		down = false;
		targetTime = downTime;
	}
}
