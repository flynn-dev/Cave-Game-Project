using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int Coins;
	public int Keys;

	//UI variables
	public Text coinDisplay;
	public Text keyDisplay;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//allows other scripts to increase the coins
	public void IncreaseCoins() {
		Coins++;
		UpdateUI ();
	}

	//allows other scripts to increase the keys
	public void IncreaseKeys() {
		Keys++;
		UpdateUI ();
	}

	//allows other scripts to decrease the coins
	public void DecreaseCoins () {
		Coins--;
		UpdateUI ();
	}
	//allows other scripts to decrease the keys
	public void DecreaseKeys() {
		Keys--;
		UpdateUI ();
	}

	//updates the ui with new values
	private void UpdateUI () {
		keyDisplay.text = "Keys: " + Keys;
		coinDisplay.text = "Coins: " + Coins;
	}

	//This function allows other scripts to check if the player has >0 keys
	public bool CheckKeys() {
		if (Keys > 0) {
			return true;
		} else {
			return false;
		}
	}
}
