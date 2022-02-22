using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHover : MonoBehaviour {

	// Use this for initialization
	void Start(){
		this.GetComponent<TextMesh>().color = Color.white;
	}

	void OnMouseEnter(){
		this.GetComponent<TextMesh>().color = Color.red;
	}

	void OnMouseExit() {
		this.GetComponent<TextMesh>().color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
