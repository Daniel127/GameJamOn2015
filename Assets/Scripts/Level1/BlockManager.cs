using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

	public GameObject[] blocks;
	public Transform[] leftGenerators;
	public Transform[] rightGenerators;

	public int position = 0;

	public bool fire = true;
	private GameObject player;
	private GameManager gameManager;
	

	void Start () {
		player = GameObject.Find("Player");
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {

		int typeBlock = Random.Range(0,blocks.Length);
		int side = Random.Range(0,2);

		GameObject block;

		if(position == leftGenerators.Length - 1){
			gameManager.endStage = true;
			Debug.Log("Fin");
			fire = false;
		}else{
			gameManager.endStage = false;
		}

		if(fire){
			if(side == 0){
				block = (GameObject) Instantiate(blocks[typeBlock], leftGenerators[position].transform.position,Quaternion.identity);
				player.GetComponent<PlayerMovement>().rotationLeft = true;
			}
			else{
				block = (GameObject) Instantiate(blocks[typeBlock], rightGenerators[position].transform.position,Quaternion.identity);
				player.GetComponent<PlayerMovement>().rotationLeft = false;
			}

			var sBlock = block.GetComponent<Block>();

			if(side != 0){
				sBlock.directionLeft = true;
			}
			sBlock.speed += (20 / rightGenerators.Length) * position;


			fire = false;

		}
	}
}
