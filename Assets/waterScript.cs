using UnityEngine;
using System.Collections;

public class waterScript : MonoBehaviour
{

	private float randomNum;
	//public Transform other;
	// Use this for initialization
	private start hpScript;
	private RaycastHit hit;
	private bool once;
	private rainbow rainbowScript;
	public GameObject player;
	private bool blacked;
	void Start ()
	{
		rainbowScript = FindObjectOfType(typeof(rainbow)) as rainbow;
		hpScript = FindObjectOfType (typeof(start)) as start;
		randomNum = Random.Range (1, 100);
		once = true;
		blacked = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.gameObject.GetComponent<Rigidbody>().isKinematic == false) {
			hpScript.currentHealth = hpScript.currentHealth - 10f * Time.deltaTime;
		}
		//Debug.Log (hit.transform.tag);

		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag == "blueCube") {
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			Debug.Log (hit.transform.tag);
		}
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag != "blueCube") {
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag == "whiteCube")
			Destroy (hit.transform.gameObject, 2f);
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag == "blackCube" && blacked == false) {
			GetComponent<CharacterController> ().enabled = false;
			Invoke ("nigafam", 2f);
			blacked = true;
		}
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag != "blackCube" && blacked == true) {
			blacked = false;
		}
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, 2f) && hit.transform.tag == "rainbowCube") {
			if ((randomNum >= 1) && (randomNum < 26)) {
				gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			} else if ((randomNum > 25) && (randomNum < 51)) {
				Destroy (hit.transform.gameObject, 2f);
			} else if ((randomNum > 51)  && (randomNum < 76)) {
				GetComponent<CharacterController> ().enabled = false;
				Invoke ("nigafam", 2f);
			} else if ((randomNum > 76) && (randomNum < 100)) {
				{
					if(once)
					{
						rainbowScript.invokeExplode();
						once = false;
					}
				}
			}
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.CompareTag ("blueCube")) {
			{
				gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			}
		}
	}

	void nigafam ()
	{
		GetComponent<CharacterController> ().enabled = true;
	}

}