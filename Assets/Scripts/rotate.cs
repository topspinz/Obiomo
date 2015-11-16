using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	public Vector3 spinRotation;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (spinRotation, speed, Space.World);
	}
}
