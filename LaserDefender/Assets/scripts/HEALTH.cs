﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HEALTH : MonoBehaviour {

    public static float healthPoints = 1000;
    public Text healthText;

	// Use this for initialization
	void Start () {
        healthPoints = 1000;
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "HEALTH: " + healthPoints;
	}
}
