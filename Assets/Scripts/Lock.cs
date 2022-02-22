using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {
	
	private bool Unlocked = false;

	//height that the door will be destroyed at when it sinks to
	public float destroyHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//makes the locked door sink when its unlocked
		if (Unlocked) {
			transform.Translate(-Vector3.up * Time.deltaTime);
		}

		//if the door gets below a certain point it gets destroyed
		if (transform.position.y <= destroyHeight) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision Collider) {
		//if collided with the player and the player has >0 keys
		if ((Collider.gameObject.layer == LayerMask.NameToLayer ("Player")) && GameObject.Find ("Main").GetComponent<GameController> ().CheckKeys () && Unlocked == false) {
			GameObject.Find ("Main").GetComponent<GameController> ().DecreaseKeys ();
			Unlocked = true;
		}
	}
}
