using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	public bool Triggered;
	public GameObject manager;

	void Start()
	{
		
	}

	void Update()
	{

	}

	private void OnTriggerEnter(Collider collider)
	{
			if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
				Trigger ();
			}
	}

	void Trigger()
	{
		Triggered = true;
		GameObject.Find("CheckpointManager").GetComponent<CheckManager>().setCurCheckpoint(gameObject);
		Debug.Log("Triggered");
	}
}