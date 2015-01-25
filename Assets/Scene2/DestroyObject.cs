using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			NotificationCenter.DefaultCenter().PostNotification(this,"PlayerDead");
			GameObject player = GameObject.Find("Player");
			GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
			gameManager.endStage = true;
			player.SetActive(false);
		}
		else{
			Destroy(other.gameObject);
		}
	}
}
