using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	Player player;
	public WayPoint playerStartingWaypoint;
	WayPoint playerCurrentWaypoint;
	public WayPoint[] waypoints;

	/*
	void Awake() {
		GameObject.DontDestroyOnLoad(this);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}
	*/
	// Use this for initialization
	void Start () {
		Input.backButtonLeavesApp = true;
		player = Player.Instance;
		WayPoint.MovePlayer += MovePlayerToWaypoint;
		//MovePlayerToWaypoint (WaypointManager.GetPlayerStartingPosition());
		MovePlayerToWaypoint(playerStartingWaypoint);
	}
		
	
	// Update is called once per frame
	void Update () {
		//MovePlayerToWaypoint(playerStartingWaypoint)
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void MovePlayerToWaypoint(WayPoint waypoint){
		print ("in move player");
		print (player);
		print (Player.Instance);
		print (waypoint);
		Player.Instance.transform.position = waypoint.transform.position;
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
