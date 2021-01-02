using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCORE : MonoBehaviour {

    public static int points = 0;
    public Text scoreText;
    public static int ships = 0;

	// Use this for initialization
	void Start () {
        points = 0;
	}
	 
	// Update is called once per frame
	void Update () {
        scoreText.text = "SCORE: " + points;

        if(ships == 0) {
            LevelControl.winGame2();
        }
	}
}
