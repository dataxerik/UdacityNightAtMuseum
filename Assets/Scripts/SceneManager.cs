using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public GameObject player;
	public WayPoint playerStartingWaypoint;
	WayPoint playerCurrentWaypoint;
	public WayPoint[] waypoints;

	// Use this for initialization
	void Start () {
		WayPoint.MovePlayer += MovePlayerToWaypoint;
		//MovePlayerToWaypoint (WaypointManager.GetPlayerStartingPosition());

		MovePlayerToWaypoint(playerStartingWaypoint);
	}
	
	// Update is called once per frame
	void Update () {
		//MovePlayerToWaypoint(playerStartingWaypoint);
	}

	public void MovePlayerToWaypoint(WayPoint waypoint){
		player.transform.position = waypoint.transform.position;
		playerCurrentWaypoint = waypoint;
		CheckWaypoints ();
		
	}

	public void MovePlayerToStart(Vector3 pos) {
		player.transform.position = pos;
	}

	public void CheckWaypoints() {
		foreach (WayPoint w in waypoints) {
			print (w);
			w.Disable ();
			foreach (WayPoint neighbor in w.neighbors) {
				if (neighbor.Equals(playerCurrentWaypoint)) {
					print ("has active neighbor " + neighbor);
					w.Activate ();
				}
			} 
		}
	}
}
