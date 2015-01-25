using UnityEngine;
using System.Collections;

public class LimitCartas : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Carta"){
			GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
			gameManager.endStage = true;
		}
	}
}
