using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour {

    public Text PONTOS;

	// Use this for initialization
	void Start () {
        PONTOS.text = "SCORE: " + SCORE.points;
    }
	
	// Update is called once per frame
	void Update () {
        
	} 
}
  