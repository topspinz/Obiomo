using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float dropSpeed;
	public float speed;
	public Vector3 respawnPoint;
	public Rigidbody rb;
	private bool death = false;
	public Text text;
	public Text restartText;
	public Light lightToDim = null;
	public GameObject cuddles;
	private int time = 3;
	//public GameObject gb;
	//public GameObject portal;
	public GameObject deathParticles;
	public GameObject babyChanDeathParticles;
	public GameObject goalParticles;
	private bool isReady = false;
	//Animation Variables
	public Animator anim;
	int jumpHash = Animator.StringToHash("Jump");



	void Start () {
		anim.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
		text.GetComponent<Text> ();
		restartText.GetComponent<Text> ();
	//	StartCoroutine (WaitAndPrint ());
		rb.isKinematic = true;
		cuddles.GetComponent<cuddleFish> ().go = false;
	}
	
	// Update is called once per frame
	void Update () {


		//Must hit the space or z key to initialize the game 
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z)) {
			isReady = true;
			rb.isKinematic = false;
			anim.SetTrigger(jumpHash);
			cuddles.GetComponent<cuddleFish> ().go = true;
		}
	
		//If the game was started by the player they may now use controls
		if(isReady == true) {
		
			if (Input.GetKey (KeyCode.RightArrow))
				rb.AddForce(new Vector3 (2.3F * speed, 0F), ForceMode.Acceleration);
			//transform.Translate (1 * speed * Time.deltaTime, 0, 0);
		
			if (Input.GetKey (KeyCode.LeftArrow)) //rb.velocity = (new Vector3 (0, 0, -1 * speed * Time.deltaTime) ); 			transform.Translate (0, 0, -1 * speed * Time.deltaTime);
			rb.AddForce(new Vector3 (-2.3F * speed, 0F), ForceMode.Acceleration);
			//transform.Translate (-1 * speed * Time.deltaTime, 0, 0 );

			//
			//
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) rb.AddForce(new Vector3 (0, 1 * dropSpeed, 0),ForceMode.Force);
		//	Debug.Log (rb.velocity.magnitude);
			if(rb.velocity.magnitude > 18) rb.velocity = rb.velocity.normalized * 18;
		}

		//If player is dead initialize restart of the game
		if (death==true) {

			if (Input.GetKey(KeyCode.R)) 
			
			{
			restartText.text = "";
			lightToDim.intensity = 1.1F;
			this.transform.position = respawnPoint;
			Application.LoadLevel(Application.loadedLevel);
			
			death = false;
		    rb.isKinematic = false; 
				rb.isKinematic = false;

			//	int value = true;
			
			}
			
		}
}



	IEnumerator WaitForGoal()
	{
		// suspend execution for 5 seconds
		rb.isKinematic = true;
		cuddles.GetComponent<cuddleFish> ().go = false;
		yield return new WaitForSeconds(1.3F);
		Application.LoadLevel(Application.loadedLevel + 1);
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("i hit em");

		if (other.gameObject.tag == "Diamond") {
			Destroy(other.gameObject);
			Instantiate(deathParticles, other.transform.position + new Vector3(0,0,-1),Quaternion.identity);
		}

		if (other.gameObject.tag == "Goal") {
			//Application.LoadLevel(Application.loadedLevel);
			Instantiate(goalParticles, other.transform.position + new Vector3(0,0,-1),Quaternion.identity);
			Destroy(other.gameObject);
			StartCoroutine(WaitForGoal());

		}

		if (other.gameObject.tag == "bomb") {

			Restart();
			Debug.Log (death);
			//transform.SetParent(true);

					
		}



		if (other.gameObject.tag == "cuddles") {

			Restart();
		
		}


		
		if (other.gameObject.tag == "Wall") {
			
			Restart();
			
		}
		



	
	}
	
	void Restart(){
		Instantiate(babyChanDeathParticles, this.transform.position + new Vector3(0,0,-1),Quaternion.identity);
		death = true;
		this.transform.position = new Vector3 (-50F,50F, 0F);
		rb.isKinematic = true;
		restartText.text = "Press 'R' to restart";
		lightToDim.intensity = 0;

	}








}
