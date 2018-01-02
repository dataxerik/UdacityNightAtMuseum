using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechButton : MonoBehaviour {

	ClassroomPerson test;
	public static event System.Action close;

	// Use this for initialization
	void Start () {
		print (GetComponentInParent<ClassroomPerson> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void closeButton() {

	}
}
