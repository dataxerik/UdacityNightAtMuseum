using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private static Player instance;
	public WayPoint playerCurrent;
	int playerLastScenePosition = -1;

	public static Player Instance {
		get { return instance; }
	}

	public static int PlayerLastScenePositionIndex {
		get { return playerLastScenePosition; }
		set { playerLastScenePosition = value; }
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void UpdateLastSceneWayPoint(){
		playerLastScenePosition = System.Array.IndexOf(Waypoints.GetWaypoints, playerCurrent);

		print (Waypoints.GetWayPointByIndex(playerLastScenePosition));
		print (playerLastScenePosition);
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
