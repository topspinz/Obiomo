using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject targetObject;
	public Vector3 offset;
	Vector3 targetPos;
	private float distanceToTarget;
	void Start () {
		Vector3 initialPosition = targetObject.transform.position;
		this.transform.position = initialPosition + offset;
		distanceToTarget = transform.position.x - targetObject.transform.position.x;
	}
	
	// LateUpdate Used to follow the player object
	void LateUpdate () {
		float targetObjectX = targetObject.transform.position.x;
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
		
	}
	
	
	
	
	
}


