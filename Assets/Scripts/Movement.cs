using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public GameObject Player;

	// Use this for initialization
	void Start () {
		WayPoint.MovePlayer += MoveToWaypoint;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToWaypoint(Vector3 waypointPosition){
		Vector3 newPos = new Vector3 (waypointPosition.x, Player.transform.position.y, waypointPosition.z);
		Player.transform.position = newPos;
	}
}
