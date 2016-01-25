using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	// Use this for initialization
	private float highScore = 0;
	void Start () {
		highScore = PlayerPrefs.GetFloat("High Score");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (highScore);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("door")) {
			if (highScore == 0) {
				highScore++;
				PlayerPrefs.SetFloat("High Score", highScore);
				Application.LoadLevel ("redRoom");
			} else if (highScore == 1) {
				highScore++;
				PlayerPrefs.SetFloat("High Score", highScore);
				Application.LoadLevel ("blueRoom");
			} else if (highScore == 2) {
				highScore++;
				PlayerPrefs.SetFloat("High Score", highScore);
				Application.LoadLevel ("blackRoom");
			} else if (highScore == 3) {
				highScore++;
				PlayerPrefs.SetFloat("High Score", highScore);
				Application.LoadLevel ("whiteRoom");
			} else if (highScore == 4) {
				highScore++;
				PlayerPrefs.SetFloat("High Score", highScore);
				Application.LoadLevel ("rainbowRoom");
			} else if (highScore == 5) {
				Application.LoadLevel ("main");
			}
			PlayerPrefs.SetFloat("High Score", highScore);
		}
	}

}
