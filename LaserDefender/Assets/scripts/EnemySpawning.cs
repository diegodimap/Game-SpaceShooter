using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public bool isMovingRight = true;
    public float speed = 5f;

    // Use this for initialization
    void Start () {
        foreach(Transform child in transform){
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
            SCORE.ships++;
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        if (isMovingRight) {
            if (this.transform.position.x < rightmost.x-width/2) {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0);
            } else {
                isMovingRight = false;    
            }
        } else {
            if (this.transform.position.x > leftmost.x+width/2) {
                this.transform.position -= new Vector3(speed * Time.deltaTime, 0);
            } else {
                isMovingRight = true;
            }
        }

        if(SCORE.ships < 5) {
            StartCoroutine(createNewShip());
        }
	}

    IEnumerator createNewShip() {
        yield return new WaitForSeconds(1);
        Transform freePosition = NextFreePosition();
        if (freePosition) {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
            SCORE.ships++;
        }
    }

   
    Transform NextFreePosition() {
        foreach(Transform child in this.transform) {
            if(child.childCount == 0) {
                return child;
            }
        }
        return null;
    }
} 
