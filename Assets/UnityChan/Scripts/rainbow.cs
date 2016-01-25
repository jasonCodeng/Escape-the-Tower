using UnityEngine;
using System.Collections;

public class rainbow : MonoBehaviour {

	public GameObject TheExplosion;
	public float maxDistance = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void setExplode()
	{
		
		Instantiate(TheExplosion, transform.position, transform.rotation);
		Destroy(this.gameObject);
		GameObject playerPos = GameObject.FindWithTag("Player");
		// what is the distance between the player and the bomb at this moment?
		float distance = Vector3.Distance(playerPos.transform.position, transform.position);
		
		if (distance < maxDistance) {
			// load the losing screen
			Application.LoadLevel("lose");
		}
	}

	public void invokeExplode()
	{
		Invoke ("setExplode", 2f);
	}

}
