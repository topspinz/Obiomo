using UnityEngine;
using System.Collections;

public class movebackground : MonoBehaviour {

	// Use this for initialization
	public float speed;
//public Renderer rend;
	public bool wrapObject; //if not quad then an object will move off screen and wrap around it 
//	public bool rendObject;
	public GameObject gobject;
	void Start () {
		//rend = GetComponent<Renderer>();
		//rend.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		//float offset = transform.position.x / transform.localScale.x * speed;
		//float offset = Time.timeSinceLevelLoad * speed ;
		//rend.material.mainTextureOffset = new Vector2(offset , 0F);

	//	rend.material.SetTextureOffset("_MainTex", new Vector2(800, 0));
	///	if (rendObject) rend.material.SetTextureOffset("_MainTex", new Vector2((transform.position.x/transform.localScale.x  * speed)%1 , 0F));

		if (wrapObject) {

			gobject.transform.Translate(speed * Time.deltaTime,0,0);

			if(gobject.transform.position.x >= 32) 
				gobject.transform.position  = new Vector3 (42,0,0);
			

		}


	}
}
