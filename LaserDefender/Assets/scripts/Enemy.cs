using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float hitpoints = 300f;
    public AudioClip impact; 
    public AudioClip explosion;
    public GameObject enemyLaser;
    public bool isFiring = false;
    public float laserVelocity = 10f;
    public float firingRate = 10f;
    public bool startFiring = false;

    private void Start() {
        StartCoroutine(comecarTiro());
    }

    void OnTriggerEnter2D(Collider2D laser) {
        float damage = laser.gameObject.GetComponent<Projectile>().damage;

        //if (laser.gameObject.GetComponent<Projectile>().isPlayer) {
            hitpoints -= damage;

            AudioSource.PlayClipAtPoint(impact, transform.position, 20f);

            Destroy(laser.gameObject);

            if (hitpoints <= 0) {
                SCORE.ships--;
                SCORE.points += 100;
                AudioSource.PlayClipAtPoint(explosion, transform.position, 5f);
                Destroy(gameObject);
            }
        //}
    }

    private void Update() {
        //Instantiate(enemyLaser, this.transform.position, Quaternion.identity);
        if(isFiring == false && startFiring)
        StartCoroutine(mostrarTiro());
    }

    IEnumerator mostrarTiro() {
        isFiring = true;
        GameObject laser2 = Instantiate(enemyLaser, this.transform.position, Quaternion.identity) as GameObject;
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserVelocity, 0);
        yield return new WaitForSeconds(firingRate);
        isFiring = false;
    }

    IEnumerator comecarTiro() {
        yield return new WaitForSeconds(2);
        startFiring = true;
    }

}  
  