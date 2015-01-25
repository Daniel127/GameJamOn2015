using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float separation = 3f;
	public Transform player;

	void LateUpdate(){
		transform.position = new Vector3(player.transform.position.x + separation, transform.position.y, transform.position.z);
	}
}
