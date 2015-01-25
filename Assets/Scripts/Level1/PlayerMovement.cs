using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	public float forceJump = 10f;
	public float speed = 1f;
	public Transform testerGround;
	public LayerMask layerMaskGround;
	
	public bool inGround = true;
	public float testerRadius = 0.1f;
	public int jump = 0;
	public bool rotationLeft = false;

	public AudioClip jumping;
	public AudioClip damage;

	public Animator animator;
	private AudioSource audio;

	void Start(){
		animator = GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
	}

	void Update(){
		if(rotationLeft){
			transform.rotation = new Quaternion(0,180,0,0);
		}
		else{
			transform.rotation = new Quaternion(0,0,0,0);
		}

		inGround = Physics2D.OverlapCircle(testerGround.position, testerRadius, layerMaskGround);
		animator.SetBool("isGrounded",inGround);

		if(inGround){
			jump = 0;
		}

		transform.position = new Vector3(0, transform.position.y,0);
		
		if(Input.GetButtonDown("Jump") && jump == 0){
			audio.PlayOneShot(jumping);
			rigidbody2D.velocity = Vector2.up * forceJump;
			jump++;
		}
		
		animator.SetFloat("SpeedJump", rigidbody2D.velocity.y);
	}

	void FixedUpdate () {


	}


}
