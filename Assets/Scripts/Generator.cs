using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] blocks;
	public float minTime = 1.3f;
	public float maxTime = 1.7f;

	void Start () {
		//Generar();
		NotificationCenter.DefaultCenter().AddObserver(this, "PlayerStart");
	}

	void PlayerStart(Notification notification){
		Generar();
	}

	void Generar(){
		Instantiate(blocks[Random.Range(0,blocks.Length)],transform.position,Quaternion.identity);
		Invoke("Generar",Random.Range(minTime,maxTime));
	}
}
