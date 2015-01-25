using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour {

	public bool left;

	private GameManager gameManager;
	private GameObject blockManager;

	void Start () {
		blockManager = GameObject.Find("BlockManager");
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Block"){
			var sBlock = collider.gameObject.GetComponent<Block>();
			if(left == sBlock.directionLeft){
				sBlock.move = false;
				var sBM = blockManager.GetComponent<BlockManager>();
				sBM.fire = true;
				if(sBM.position < sBM.leftGenerators.Length - 1){
					sBM.position++;
				}
				collider.gameObject.transform.position = new Vector3(0,collider.gameObject.transform.position.y,0);
				if(sBlock.error){
					gameManager.AddScore(-1);
				}
				else{
					gameManager.AddScore(2);
				}
			}

		}
	}
}
