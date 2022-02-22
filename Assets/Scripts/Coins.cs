using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

	private int CoinSpeed = 130;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, CoinSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Destroy (gameObject);
			GameObject.Find("Main").GetComponent<GameController>().IncreaseCoins();
		}
	}
}
