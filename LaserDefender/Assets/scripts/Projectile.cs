using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float damage = 100f;
    //public bool isPlayer = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        print("laser x laser");
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
