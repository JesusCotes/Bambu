﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUpdateNZCoins : MonoBehaviour {
	public Text coins;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coins.text = GlobalValue.NZCoins.ToString();
	}
}
