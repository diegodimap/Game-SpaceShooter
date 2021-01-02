using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	
	public float velocity;
	public float minX;
	public float maxX;
    public GameObject tiro;
    public GameObject laser1;
    public GameObject levelControl;  
    public float laserVelocity;
    public bool isFiring = false;
    public float firingRate = 0.2f;
    public AudioClip explosionDeath;
    public AudioClip hit;

    void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		minX = leftmost.x;
		maxX = rightmost.x;
		
		velocity = 7.5f;
		//minX = -15f;
		//maxX = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			if(transform.position.x > minX)
			this.transform.position += new Vector3(-velocity*Time.deltaTime, 0,0);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			if(transform.position.x < maxX)
			this.transform.position += new Vector3(velocity*Time.deltaTime, 0,0);
		}
        if (Input.GetKey(KeyCode.Space)) {
           // print("TIRO");
            if (!isFiring)
                StartCoroutine(mostrarTiro());
        }
        if (Input.GetMouseButton(0)) {
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            if (mouseY < Screen.height / 2) {
                if (transform.position.x < maxX && mouseX > Screen.width / 2) {
                    this.transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
                } else if (transform.position.x > minX && mouseX < Screen.width / 2) {
                    this.transform.position -= new Vector3(velocity * Time.deltaTime, 0, 0);
                }
            } else {
                //print("TIRO");
                if(!isFiring)
                    StartCoroutine(mostrarTiro());
                
            }
        }

        if (Application.isMobilePlatform) {
            if (!isFiring)
                StartCoroutine(mostrarTiro());
        }
	} 

    IEnumerator mostrarTiro() {
        isFiring = true;
        GameObject laser2 = Instantiate(laser1, this.transform.position, Quaternion.identity) as GameObject;
        laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserVelocity, 0);
        yield return new WaitForSeconds(firingRate);
        isFiring = false;
    }

    void OnTriggerEnter2D(Collider2D laser) {
        //float damage = laser.gameObject.GetComponent<Projectile>().damage;

       // if (!laser.gameObject.GetComponent<Projectile>().isPlayer) {
            AudioSource.PlayClipAtPoint(hit, transform.position, 20f);
            HEALTH.healthPoints -= 100;
            Destroy(laser.gameObject);

            if (HEALTH.healthPoints <= 0) {
                AudioSource.PlayClipAtPoint(explosionDeath, transform.position, 20f);
                LevelControl.loseGame2();
                Destroy(gameObject);
            }

            print("atingido: " + HEALTH.healthPoints);
       // }
    }
}
