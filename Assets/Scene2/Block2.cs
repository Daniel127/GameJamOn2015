using UnityEngine;
using System.Collections;

public class Block2 : MonoBehaviour {

	private bool addScore = true;

	void Start () {
		
	}
	
	void Update () {

	}

	void OnCollisionStay2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			var sPlayer = collision.gameObject.GetComponent<PlayerController>();
			if(!sPlayer.inGround){
				sPlayer.rigidbody2D.velocity = new Vector2(-5, -3);
				Debug.Log("Intro");
			}
		}
	}
}
