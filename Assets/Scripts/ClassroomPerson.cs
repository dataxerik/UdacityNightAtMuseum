using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassroomPerson : MonoBehaviour {

	public AudioSource greetAudio;
	public AudioSource goodbyeAudio;
	public Canvas speechBubble;

	// Use this for initialization
	void Start () {
		print (speechBubble.GetComponentInChildren<Button> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Talk() {
		greetAudio.Play ();
		speechBubble.enabled = true;
	}

	public void Goodbye() {
		goodbyeAudio.Play ();
		speechBubble.enabled = false;
	}
}
