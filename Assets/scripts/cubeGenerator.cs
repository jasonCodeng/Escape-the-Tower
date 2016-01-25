using UnityEngine;
using System.Collections;

public class cubeGenerator : MonoBehaviour {

	public int range;
	public float rate;
	public GameObject Cube;
	public GameObject redCube;
	public GameObject blueCube;
	public GameObject whiteCube;
	public GameObject blackCube;
	public GameObject pinkCube;
	public GameObject rainbowCube;

	public float maximum = 360f;

	private Vector3 originPosition;
	private float randomNum;


	// Use this for initialization
	void Start () {
		Random.seed = (int)System.DateTime.Now.Ticks;
		originPosition = transform.position;
		InvokeRepeating("spawnCubes", 0f, rate);
	}
	
	// Update is called once per frame
	void Update () {
		randomNum = Random.Range (1, 100);

	}

	void spawnCubes(){
		Vector3 randomPosition = originPosition + new Vector3 (Random.Range(range * -1, range) * 3, transform.position.y , Random.Range(range * -1, range) * 3);
		if((randomNum >= 1) && (randomNum < 50))
			Instantiate(Cube, randomPosition, Quaternion.identity);
		else if((randomNum >= 50) && (randomNum < 60))
			Instantiate(redCube, randomPosition, Quaternion.identity);
		else if((randomNum >= 60) && (randomNum < 70))
			Instantiate(blueCube, randomPosition, Quaternion.identity);
		else if((randomNum >= 70) && (randomNum < 80))
			Instantiate(whiteCube, randomPosition, Quaternion.identity);
		else if((randomNum >= 80) && (randomNum < 90))
			Instantiate(blackCube, randomPosition, Quaternion.identity);
		else if((randomNum >= 90) && (randomNum < 100))
			Instantiate(rainbowCube, randomPosition, Quaternion.identity);


		//Destroy(clone, 1f);
	}

}
