using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private static Player instance;
	public static Player Instance {
		get { return instance; }
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void Awake() {
		print ("in Player awake");
		if (instance == null) {
			instance = this;
		}
		else if (instance !=this)
		{
			Destroy(gameObject);
			return;
		}
	}

}
