using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class start : MonoBehaviour {
	public GameObject spawner;
	private bool once = true;
	public Text HP;
	public Text text;
	public float startingHealth = 100;                            // The amount of health the player starts the game with.
	public float currentHealth;                                   // The current health the player has.

	void Awake ()
	{
		// Setting up the references.
		//anim = GetComponent <Animator> ();
		//playerMovement = GetComponent <PlayerMovement> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	// Use this for initialization
	void Start () {
		Invoke ("disableText", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && once) {
			once = false;
			gameObject.GetComponent<CharacterController>().enabled = true;
			//text.enabled = false;
			spawner.SetActive(true);
		}
		SetCountText ();
	}

	void disableText()
	{
		text.enabled = false;
	}

	void SetCountText()
	{
		HP.text = "HP: " + currentHealth.ToString ("F0");
		if(currentHealth <= 0)
		{
			PlayerPrefs.DeleteAll();
			Application.LoadLevel("lose");
		}
	}     
}
