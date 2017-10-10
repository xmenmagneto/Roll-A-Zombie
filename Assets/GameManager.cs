using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int selectedZombiePosition = 0;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;
	public Text text;
	int score = 0;

	// Use this for initialization
	void Start () {
		SelectZombie(zombies [0], 0); 
		text.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("left"))
			GetZombieLeft ();

		if (Input.GetKeyDown ("right"))
			GetZombieRight ();

		if (Input.GetKeyDown ("up"))
			PushUp ();
	
	}

	void GetZombieLeft() {
		if (selectedZombiePosition == 0) {
			SelectZombie (zombies [3], 3);
		} else {
			SelectZombie (zombies [selectedZombiePosition - 1], selectedZombiePosition - 1);
		}
	}

	void GetZombieRight() {
		if (selectedZombiePosition == 3) {
			SelectZombie (zombies [0], 0);
		} else {
			SelectZombie(zombies[selectedZombiePosition + 1], selectedZombiePosition + 1);
		}
	}

	void SelectZombie(GameObject newZombie, int newPosition) {
		selectedZombie.transform.localScale = defaultSize;

		selectedZombie = newZombie;

		selectedZombie.transform.localScale = selectedSize;

		selectedZombiePosition = newPosition;
	}

	void PushUp() {
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 10, ForceMode.Impulse);
	}

	public void AddScore() {
		score = score + 1;
		text.text = "Score: " + score;
	}
}
