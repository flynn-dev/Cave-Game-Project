using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	private int KeySpeed = 130;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, KeySpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider collider)
	{
		//if the key collides with the player, destroy the key and increase keys in the GameController script on the main object
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Destroy (gameObject);
			GameObject.Find("Main").GetComponent<GameController>().IncreaseKeys();
		}
	}
}
