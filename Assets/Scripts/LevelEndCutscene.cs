using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndCutscene : MonoBehaviour {

	public bool move = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			GameObject.Find("Player").GetComponent<Platformer>().movePlayer(6, 0);
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			GameObject.Find("Main Camera").GetComponent<SmoothCamera>().TurnOff();
			move = true;
		}
	}
}

