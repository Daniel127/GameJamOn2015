using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	void Start () {
		MovieTexture texture = (MovieTexture) renderer.material.mainTexture;
		texture.Play();
		audio.Play();
	}
	
	void Update () {
	
	}
}
