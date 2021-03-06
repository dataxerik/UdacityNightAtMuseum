﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
	private static WayPoint[] waypoints;
	public static WayPoint[] GetWaypoints {
		get { return waypoints; }
	}	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake() {
		waypoints = GameObject.FindObjectsOfType<WayPoint> ();
	}

	public static WayPoint GetWayPointByIndex(int index){
		return GetWaypoints[index];
	}

}
