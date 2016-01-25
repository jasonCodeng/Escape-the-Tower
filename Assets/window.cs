using UnityEngine;
using System.Collections;

public class window : MonoBehaviour {

	private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (this.transform.position, Vector3.forward, out hit, 2f) && hit.transform.tag == "window") {
			PlayerPrefs.DeleteAll();
			Application.LoadLevel("win");
		}
	}
}
