using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour {
	InfoSign mySign;
	InfoSignButton mySignButton;
	InfoDisplay myInfoDisplay;

	// Use this for initialization
	void Start () {
		print ("...........In the start method for INFOSIGN............");
		mySign = GetComponentInChildren<InfoSign> ();
		mySignButton = GetComponentInChildren<InfoSignButton> ();
		myInfoDisplay = GetComponentInChildren<InfoDisplay> ();
		Close ();
		DisableSignAndInfo ();
		print ("My signbutton is " + mySignButton);
		print ("My signbutton sign is " + mySignButton.sign);
		print ("My signbutton sign renderer is " + mySignButton.sign.GetComponent<MeshRenderer>());
	}
	
	// Update is called once per frame
	void Update () {	
		print ("My signbutton is " + mySignButton);
		print ("My signbutton sign is " + mySignButton.sign);
		print ("My signbutton sign renderer is " + mySignButton.sign.GetComponent<MeshRenderer>());	
	}

	private void Awake() {
		
		mySign = GetComponentInChildren<InfoSign> ();
		mySignButton = GetComponentInChildren<InfoSignButton> ();
		myInfoDisplay = GetComponentInChildren<InfoDisplay> ();
	
	}

	void Display() {
		//mySignButton.D
		print("Displayed!");
		mySignButton.DisableButton ();
		myInfoDisplay.ShowInfo ();
	}

	void Close() {
		print ("closed");
		mySignButton.EnableButton ();
		myInfoDisplay.HideInfo ();
	}

	void OnEnable() {
		/*
		mySign = GetComponentInChildren<InfoSign> ();
		mySignButton = GetComponentInChildren<InfoSignButton> ();
		myInfoDisplay = GetComponentInChildren<InfoDisplay> ();*/
		InfoSignButton.DisplayMyInfo += Display;
		print ("added behavior to myDisplayInfo");

		InfoDisplay.CloseInfoBox += Close;
		print ("added behavor to CloseInfoeBox");
	}

	public void DisableSignAndInfo() {
		myInfoDisplay.DisableInfo ();
		mySignButton.DisableButton ();
	}

	public void EnableSignAndInfo() {
		if (myInfoDisplay.DisplayIsUp()) {
			myInfoDisplay.EnableInfo ();
		} else {
			mySignButton.EnableButton ();
			myInfoDisplay.EnableInfo ();
		}
	}
}
