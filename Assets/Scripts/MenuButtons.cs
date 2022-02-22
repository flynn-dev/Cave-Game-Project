using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public bool isStart;
	public bool isQuit;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseUp() {
		if (isQuit) {
			Application.Quit ();
		} if(isStart) {
			SceneManager.LoadScene (1);
			//Application.LoadLevel (1);
			this.GetComponent<TextMesh>().color = Color.cyan;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
