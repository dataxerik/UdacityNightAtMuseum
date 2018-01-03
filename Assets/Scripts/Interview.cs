using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interview : MonoBehaviour {

	public AudioSource interview;
	public Text buttonText;
	string playText = "Play interview";
	string stopText = "Stop interview";

	public void PlayInterview() {
		if (!interview.isPlaying) {
			interview.Play ();
			buttonText.text = stopText;
		} else {
			interview.Stop ();
			buttonText.text = stopText;
		}
	}
}
