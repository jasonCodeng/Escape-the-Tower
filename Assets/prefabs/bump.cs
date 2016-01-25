using UnityEngine;
using System.Collections;

public class bump : MonoBehaviour {

	private RaycastHit hit;
	private bool femfem;
	// Use this for initialization
	void Start () {
		femfem = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, Vector3.down, out hit, 2f) && !femfem){
			Debug.Log("FEM");
			playClip();
			femfem = true;
		}
	}

	void playClip()
	{
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
