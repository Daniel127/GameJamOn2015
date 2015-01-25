using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

	public float speed = 10f;
	private bool move = false;

	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PlayerStart");
		NotificationCenter.DefaultCenter().AddObserver(this, "PlayerDead");
	}

	void PlayerStart(Notification notification){
		move = true;
	}

	void PlayerDead(Notification notification){
		move = false;
	}
	
	void Update () {
		if(move){
			renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0);
		}
	}
}
