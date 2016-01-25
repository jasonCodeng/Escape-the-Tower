using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r"))
			Application.LoadLevel ("hallway");
		else if (Input.GetKeyDown ("m"))
			Application.LoadLevel ("main");
	}
}
