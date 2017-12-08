using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	public GameObject player;
	public WayPoint playerStartingWaypoint;

	public static event System.Action CheckWaypoints;

	// Use this for initialization
	void Start () {
		WayPoint.MovePlayer += MovePlayerToWaypoint;
		//MovePlayerToWaypoint (WaypointManager.GetPlayerStartingPosition());
		MovePlayerToWaypoint(playerStartingWaypoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MovePlayerToWaypoint(Vector3 waypointPosition){
		player.transform.position = waypointPosition;
		if (CheckWaypoints != null) {
			print ("Checking waypoints..");
			CheckWaypoints ();
		}
	}
}
