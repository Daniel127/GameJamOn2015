using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

	GameManager gameManager;
	PlayerController sPlayer;

	void Start() {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		sPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			sPlayer.speed = 0f;
			Camera.main.audio.Stop();
			sPlayer.audio.PlayOneShot(sPlayer.final);
			gameManager.endStage=true;
			Debug.Log("Termina");
		}
	}

}
