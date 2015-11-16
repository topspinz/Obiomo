using UnityEngine;
using System.Collections;

public class cuddleFish : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public bool go;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (go) {
			transform.Translate (-Vector3.right * speed * Time.deltaTime);

		}

	}
}
