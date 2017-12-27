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
			GvrCardboardHelpers.Recenter();
		} else {
			MovePlayerToStart (Waypoints.GetWayPointByIndex(Player.PlayerLastScenePosition));
			print (Quaternion.LookRotation (gameObject.transform.position));
			GvrCardboardHelpers.Recenter();
			print(".....................................................looking at this object now.......................");
			print (Quaternion.LookRotation (Player.Instance.transform.position - GameObject.FindGameObjectWithTag("MiddleWaypoint").transform.position).eulerAngles);

			print (Quaternion.LookRotation (Player.Instance.transform.position - Waypoints.GetWayPointByIndex(Player.PlayerLastScenePosition).transform.position).eulerAngles);
			Player.Instance.transform.rotation = Quaternion.LookRotation (Player.Instance.transform.position - GameObject.FindGameObjectWithTag ("MiddleWaypoint").transform.position); //.eulerAngles.y;
			isReturningToHub = false;
		}
		Vector3 vectorToMiddle = Player.Instance.transform.position + gameObject.transform.position;
		print ("Vector to Middle is " + vectorToMiddle);
		print ("Angle is " + Mathf.Acos (vectorToMiddle.x / vectorToMiddle.z) * Mathf.Rad2Deg);
		//MovePlayerToWaypoint(playerStartingWaypoint);
		//CheckWaypoints (Waypoints.GetWaypoints);
	}
		
	
	// Update is called once per frame
	void Update () {
		//MovePlayerToWaypoint(playerStartingWaypoint)
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		//print (Player.Instance.GetComponentInChildren<Camera> ().transform.eulerAngles);
		//print ("Player rotation is " + Player.Instance.transform.rotation);
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
		print ("waypoing position is " + waypoint.transform.position);
		print ("Player rotation is " + Player.Instance.transform.rotation);
		print ("Waypoint rotation is " + waypoint.transform.rotation);
		print ("Camera rotation is " + Player.Instance.GetComponentInChildren<Camera> ().transform.eulerAngles.y);

		//Player.Instance.transform.eulerAngles = new Vector3(0, 90, 0);
		//GvrCardboardHelpers.Recenter();
		print ("Player rotation is " + Player.Instance.transform.rotation);
		Player.Instance.playerCurrent = waypoint;
		if (CheckInfoSigns != null) {
			CheckInfoSigns ();
		} else {
			print ("CheckInfoSigns is not assigned to a function");
		}
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
