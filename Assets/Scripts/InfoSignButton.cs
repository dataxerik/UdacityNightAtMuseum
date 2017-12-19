using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSignButton : MonoBehaviour {

	public GameObject sign;
	public Material signEnabled;
	public Material signDisabled;
	Button infoButton;
	MeshRenderer infoButtonRenderer;

	// Use this for initialization
	void Start () {
		infoButton = GetComponent<Button> ();
		infoButtonRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayInfo() {
		print("clicked.......");
		DisableButton ();


	}

	void DisableButton() {
		ChangeMaterial (DisableButton);
	}

	void EnableButton() {
		ChangeMaterial (EnableButton);
	}

	void ChangeMaterial(Material material) {
		infoButtonRenderer.material = material;
	}
}
