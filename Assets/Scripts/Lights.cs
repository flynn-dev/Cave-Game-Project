using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {

	public float pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(GameObject.Find("Player").transform.position.x + pos, GameObject.Find("Player").transform.position.y + 0.5f, 0.05f);
	}
}
