using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interview : MonoBehaviour {

	public AudioSource interview;

	public void PlayInterview() {
		if (!interview.isPlaying) {
			interview.Play ();
		}
	}
}
