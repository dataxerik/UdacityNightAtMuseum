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
		print ("My signbutton is " + mySignButton.GetInstanceID());
		print ("My signbutton sign is " + mySignButton.sign.GetInstanceID());
		print ("My signbutton sign renderer is " + mySignButton.sign.GetComponent<MeshRenderer>().GetInstanceID());
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
		InfoSignButton.DisplayMyInfo += Display;
		print ("added behavior to myDisplayInfo");

		InfoDisplay.CloseInfoBox += Close;
		print ("added behavor to CloseInfoeBox");
	}

	void OnDisable() {
		InfoSignButton.DisplayMyInfo -= Display;
		InfoDisplay.CloseInfoBox -= Close;
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
