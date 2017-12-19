using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSignButton : MonoBehaviour {

	public GameObject sign;
	public Material signEnabled;
	public Material signDisabled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayInfo() {
		print("clicked.......");
		sign.GetComponent<MeshRenderer> ().material = signDisabled;

	}
}
