using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSignManager : MonoBehaviour {

	const double enableDistance = 3.2;

	static InfoSign[] infosigns;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
		print ("......running awaking for InfoSignManager......");
		infosigns = GameObject.FindObjectsOfType<InfoSign> ();
	}

	void OnEnable() {
		//infosigns = GameObject.FindObjectsOfType<InfoSign> ();
		SceneManager.CheckInfoSigns += CalculateDistance;
	}

	void OnDisable() {
		SceneManager.CheckInfoSigns -= CalculateDistance;
	}

	void CalculateDistance() {
		print ("checking info signs....");
		foreach(InfoSign sign in infosigns) {
			print ("distance is " + Vector3.Distance (Player.Instance.transform.position, sign.transform.position));
			if (Vector3.Distance (Player.Instance.transform.position, sign.transform.position) <= enableDistance) {
				sign.EnableSignAndInfo ();
			} else {
				sign.DisableSignAndInfo ();
			}
		}
	}


}
