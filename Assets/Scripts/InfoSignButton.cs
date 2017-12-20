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
	void Start () {
		infoButton = GetComponent<Button> ();
		infoSignRenderer = sign.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
		infoButton.interactable = false;
	}

	public void EnableButton() {
		ChangeMaterial (signEnabled);
		infoButton.interactable = true;
	}

	void ChangeMaterial(Material material) {
		infoSignRenderer.material = material;
	}
}
