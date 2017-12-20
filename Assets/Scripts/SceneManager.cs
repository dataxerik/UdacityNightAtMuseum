using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	Player player;
	public WayPoint playerStartingWaypoint;
	public static bool isReturningToHub = false;
	public static event System.Action CheckInfoSigns;
	WayPoint playerCurrentWaypoint;
	WayPoint[] waypoints;

	// Use this for initialization
	void Start () {
		print ("in SceneManager start method.......");

		Input.backButtonLeavesApp = true;
		player = Player.Instance;
		WayPoint.MovePlayer += MovePlayerToWaypoint;

		Player.Instance.transform.eulerAngles = playerStartingWaypoint.transform.eulerAngles;
		print (Player.PlayerLastScenePosition);
		//print(Waypoints.GetWayPointByIndex(Player.Instance.playerLastScenePosition));
		if (!isReturningToHub) {
			MovePlayerToStart (playerStartingWaypoint);
		} else {
			MovePlayerToStart (Waypoints.GetWayPointByIndex(Player.PlayerLastScenePosition));
			isReturningToHub = false;
		}
		//MovePlayerToWaypoint(playerStartingWaypoint);
		CheckWaypoints (Waypoints.GetWaypoints);
	}
		
	
	// Update is called once per frame
	void Update () {
		//MovePlayerToWaypoint(playerStartingWaypoint)
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		//print (Player.Instance.GetComponentInChildren<Camera> ().transform.eulerAngles);
	}

	public void MovePlayerToWaypoint(WayPoint waypoint){
		Player.Instance.transform.position = waypoint.transform.position;
		Player.Instance.playerCurrent = waypoint;
		CheckWaypoints (Waypoints.GetWaypoints);

		if (CheckInfoSigns != null) {
			CheckInfoSigns ();
		} else {
			print ("CheckInfoSigns is not assigned to a function");
		}
		
	}

	public void MovePlayerToStart(WayPoint waypoint) {
		Player.Instance.transform.position = waypoint.transform.position;
		Player.Instance.transform.eulerAngles = waypoint.transform.eulerAngles;
		Player.Instance.playerCurrent = waypoint;
		CheckWaypoints (Waypoints.GetWaypoints);
	}

	public void CheckWaypoints(WayPoint[] waypointSystem) {
		foreach (WayPoint w in waypointSystem) {
			w.Disable ();
			foreach (WayPoint neighbor in w.neighbors) {
				if (neighbor.Equals(Player.Instance.playerCurrent)) {
					w.Activate ();
				}
			} 
		}
	}

}
