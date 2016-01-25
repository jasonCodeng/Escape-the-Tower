using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour {
	
	// Use this for initialization
	static bool AudioBegin = false; 
	void Awake()
	{
		if (!AudioBegin) {
			GetComponent<AudioSource>().Play ();
			DontDestroyOnLoad (gameObject.GetComponent<AudioSource>());
			AudioBegin = true;
		} 
	}
	void Update () {
		if(Application.loadedLevelName == "hallway")
		{
			GetComponent<AudioSource>().Stop();
			AudioBegin = false;
		}
	}
}
