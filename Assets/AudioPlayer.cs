using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
	public GameObject other;
	void Awake()
	{
		if (!other.GetComponent<AudioSource>().isPlaying) {
			other.GetComponent<AudioSource>().Play();
			DontDestroyOnLoad (other);
		//	other.GetComponent<AudioSource>().enabled = true;
		} 
	}

		
	}
