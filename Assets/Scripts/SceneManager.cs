using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	Player player;
	public WayPoint playerStartingWaypoint;
	WayPoint playerCurrentWaypoint;
	WayPoint[] waypoints;

	// Use this for initialization
	void Start () {
		Input.backButtonLeavesApp = true;
		player = Player.Instance;
		WayPoint.MovePlayer += MovePlayerToWaypoint;

		//waypoints = GameObject.FindObjectsOfType<WayPoint> ();
		//MovePlayerToWaypoint (WaypointManager.GetPlayerStartingPosition());
		MovePlayerToWaypoint(playerStartingWaypoint);
		CheckWaypoints (Waypoints.GetWaypoints);
	}
		
	
	// Update is called once per frame
	void Update () {
		//MovePlayerToWaypoint(playerStartingWaypoint)
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void MovePlayerToWaypoint(WayPoint waypoint){
		Player.Instance.transform.position = waypoint.transform.position;
		playerCurrentWaypoint = waypoint;
		CheckWaypoints (Waypoints.GetWaypoints);
		
	}

	public void MovePlayerToStart(Vector3 pos) {
		Vector3 newPos = new Vector3 (pos.x, Vector3.forward.y, pos.z);
		player.transform.position = pos;
		player.transform.rotation = Quaternion.LookRotation (pos.y - Vector3.forward);
		//player.transform.LookAt(Vector3.zero);
	}

	public void CheckWaypoints(WayPoint[] waypointSystem) {
		foreach (WayPoint w in waypointSystem) {
			print (w);
			w.Disable ();
			foreach (WayPoint neighbor in w.neighbors) {
				if (neighbor.Equals(playerCurrentWaypoint)) {
					w.Activate ();
				}
			} 
		}
	}


}
