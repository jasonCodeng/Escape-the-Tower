using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class cubeCollision : MonoBehaviour {

public float maxDistance = 3f;
public GameObject TheExplosion;
	private start hpScript;
	private Rigidbody body;
	private GameObject dScript;
	// Use this for initialization
	void Start () {
		hpScript = FindObjectOfType (typeof(start)) as start;
		body = GetComponent<Rigidbody>();
		body.AddForce (Physics.gravity * 10);
		//bool grounded = false;
	}


	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other)
	{
		GameObject target = other.gameObject;
		if (this.gameObject.tag == "redCube") {
			if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("cube")) {
				Invoke ("setExplode", 2f);
			}

		}
		if (other.gameObject.CompareTag ("Player")) {
			target.GetComponent<FirstPersonController> ().enabled = false;
			//dScript = other.gameObject.GetComponents<FirstPersonController>();
			//Gameobject cam = GameObject.FindGameObjectsWithTag("Cam2");

			PlayerPrefs.DeleteAll();
			Application.LoadLevel("lose");
		}
	}

	void setExplode()
	{
		Destroy(this.gameObject);

		Instantiate(TheExplosion, transform.position, transform.rotation);
		GameObject playerPos = GameObject.FindWithTag("Player");
        // what is the distance between the player and the bomb at this moment?
        float distance = Vector3.Distance(playerPos.transform.position, transform.position);
 
		if (distance < maxDistance) {
        // load the losing screen
        //Application.LoadLevel("lose");
			hpScript.currentHealth = hpScript.currentHealth - 50f;	
	}
	}
	void setKinematic()
	{
		body.isKinematic = true;
	}

}
