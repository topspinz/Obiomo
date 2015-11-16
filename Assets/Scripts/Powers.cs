using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public bool upAndDownMode;
	public bool leftandRightMode;
	public float min;
	public float max;
	public bool rotate360 =false;
	private Vector3 MovingDirection = Vector3.up;
	private Vector3 MovingDirection2 = Vector3.right;
	// Update is called once per frame

	
	void Update() {
		float angle = 360.0f;
		float time = 1.0f;
		Vector3 axis = Vector3.forward;
		
		if (upAndDownMode) {
			gameObject.transform.Translate(MovingDirection * speed * Time.smoothDeltaTime);
			if(transform.position.y > max) MovingDirection = Vector3.down;
			else if(transform.position.y < min) MovingDirection = Vector3.up;
			
		}
		
		if (leftandRightMode) {
			gameObject.transform.Translate(MovingDirection2 * speed * Time.smoothDeltaTime);
			if(transform.position.x > max) {
				MovingDirection2 = Vector3.right; 
				transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
				//speed = speed * -1;
			}
			else if(transform.position.x < min) {
				MovingDirection2 = Vector3.right; 
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
				//speed = speed * -1;
			}
			
		}




		if(rotate360) transform.Rotate (Vector3.forward*Time.deltaTime* speed,Space.World);
		
		
		
	}
	
	
	
}