using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    static Music instance = null;

    void Awake() {
       // print("AWAKE ID=" + GetInstanceID());
        if (instance != null) {
            Destroy(gameObject);
           // print("DESTROY ID=" + GetInstanceID());
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
