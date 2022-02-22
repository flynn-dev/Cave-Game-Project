using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour {
	
	public GameObject curCheckpoint;	//this variable tracks the last checkpoint that the player touched
	void Start() {
	
	}


	public void setCurCheckpoint(GameObject input) {
		curCheckpoint = input;
	}

	//this function allows other scripts to get the curCheckpoint
	public GameObject getCheckpoint()
	{
		return curCheckpoint;
	}
}