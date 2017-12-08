using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {
	public static WayPoint playerStartingWaypoint;

	public WayPoint[] waypoints;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void DisableAllWaypoints() {
		foreach (WayPoint w in waypoints) {
			w.Disable ();
		}
	}

	public Vector3 GetPlayerStartingPosition(){
		return playerStartingWaypoint.transform.position;
	}
}
