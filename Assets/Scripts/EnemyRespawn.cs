using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour {

	Vector3 OriginalPos;

	// Use this for initialization
	void Start () {
		OriginalPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetPosition() {
		gameObject.transform.position = OriginalPos;	

	}
}
