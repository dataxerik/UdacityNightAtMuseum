using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour {

	public static event System.Action CloseInfoBox;

	public Canvas infoDisplayCanvas;
	Button closeButton;

	// Use this for initialization
	void Awake () {
		
		closeButton = GetComponent<Button> ();

	}

	void OnEnable() {
		/*
		closeButton = GetComponent<Button> ();
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick() {
		if (CloseInfoBox != null) {
			CloseInfoBox ();
		} else {
			print ("Event wasn't assigned");
		}
	}

	public void HideInfo() {
		infoDisplayCanvas.enabled = false;
	}

	public void ShowInfo() {
		infoDisplayCanvas.enabled = true;
	}

	public void DisableInfo() {
		closeButton.enabled = false;
	}

	public void EnableInfo(){
		closeButton.enabled = true;
	}

	public bool DisplayIsUp(){
		return infoDisplayCanvas.enabled;
	}
}
