using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour {
	InfoSign mySign;
	InfoSignButton mySignButton;
	InfoDisplay myInfoDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake() {
		mySign = GetComponentInChildren<InfoSign> ();
		mySignButton = GetComponentInChildren<InfoSignButton> ();
		myInfoDisplay = GetComponentInChildren<InfoDisplay> ();
	}

	void Display() {
		//mySignButton.D
		print("Displayed!");
	}

	void OnEnable() {
		InfoSignButton.DisplayMyInfo += Display;
		print ("added behavior to myDisplayInfo");
	}
}
