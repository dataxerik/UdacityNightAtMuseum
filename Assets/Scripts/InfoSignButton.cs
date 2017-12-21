using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSignButton : MonoBehaviour {

	public GameObject sign;
	public Material signEnabled;
	public Material signDisabled;
	public static event System.Action DisplayMyInfo;
	Button infoButton;
	MeshRenderer infoSignRenderer;

	// Use this for initialization
	void Awake () {
		
		infoButton = GetComponent<Button> ();
		infoSignRenderer = sign.GetComponent<MeshRenderer> ();
		print ("........in InfoSignButton awake method ... " + sign.GetComponent<MeshRenderer> ());
		print ("............ sign is currently set to.......... " + sign);

	}

	void OnEnable() {
		/*
		infoButton = GetComponent<Button> ();
		infoSignRenderer = sign.GetComponent<MeshRenderer> ();
		print ("in InfoSignButton start method ... " + sign.GetComponent<MeshRenderer> ());
		*/
	}
	
	// Update is called once per frame
	void Update () {
		//print (this + " " + sign);
	}

	public void OnClick() {
		if (DisplayMyInfo != null) {
			DisplayMyInfo ();
		} else {
			print ("couldn't assign a function to the delegate......");
		}
	}

	public void DisableButton() {
		ChangeMaterial (signDisabled);
		infoButton.enabled = false;
	}

	public void EnableButton() {
		ChangeMaterial (signEnabled);
		infoButton.enabled = true;
	}

	void ChangeMaterial(Material material) {
		if (infoSignRenderer == null) {
			print ("Trying to change the material of " + sign.GetInstanceID());
			print ("Materials are " + signEnabled + " " + signDisabled);
			print (" this is " + this);
			print (" this is " + this.sign);
			//infoSignRenderer = sign.GetComponent<MeshRenderer> ();
		}
		print ("render is set to " + infoSignRenderer);
		infoSignRenderer.material = material;
	}
}
