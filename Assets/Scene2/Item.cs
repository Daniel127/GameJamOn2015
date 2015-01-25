using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	private GameManager gameManager;
	private PlayerController sPlayer;

	void Start(){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		sPlayer = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Player"){
			gameManager.AddScore(5);
			Destroy(this.gameObject);
			sPlayer.audio.PlayOneShot(sPlayer.item);
		}
	}
}
