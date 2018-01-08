using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interview : MonoBehaviour {

	public AudioSource interview;
	public Text buttonText;
	bool isPlaying = false;
	string playText = "Play interview";
	string stopText = "Pause interview";

	void Update() {
		updateAudioDisplayText ();
	}

	void updateAudioDisplayText() {
		if (buttonText.text.Equals (stopText) && !interview.isPlaying) {
			buttonText.text = playText;
		}
	}

	public void PlayInterview() {
		if (!interview.isPlaying) {
			interview.Play ();
			buttonText.text = stopText;
		} else {
			interview.Pause ();
			print (interview.time);
			buttonText.text = playText;
		}
	}
}
