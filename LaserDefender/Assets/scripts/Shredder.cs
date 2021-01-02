using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D laser) {
        Destroy(laser.gameObject);
        //print("COLLIDER!");
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(collision.gameObject);
        //print("COLLISION!");
    } 
}  
  