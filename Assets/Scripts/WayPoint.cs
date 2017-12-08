using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {
	public bool isPlayerAtThisWaypoint = false;
	Collider waypointCollider;
	MeshRenderer waypointRenderer;

	public static event System.Action<WayPoint> MovePlayer;

	public Material materialActive;
	public Material materialInactive;
	public Material materialHover;
	public WayPoint[] neighbors;

	// Use this for initialization
	void Start () {
		waypointCollider = GetComponent<Collider> ();
		waypointRenderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if (MovePlayer != null) {
			isPlayerAtThisWaypoint = true;
			MovePlayer(this);
		}
	}

	public void OnHovering() {
		ChangeToHoverMaterial ();
	}

	public void OnExit() {
		ChangeToActiveMaterial ();
	}

	public void Disable() {
		print ("before disable update " + waypointCollider.enabled);
		ChangeToInactiveMaterial ();
		SetColliderState (false);
		print ("after disable update " + waypointCollider.enabled);
	}

	public void Activate() {
		print ("activate is being called....");
		ChangeToActiveMaterial ();
		SetColliderState (true);
	}

	// Methods about changing waypoint material

	void ChangeMaterial(Material material) {
		waypointRenderer.material = material;
	}

	void ChangeToActiveMaterial(){
		ChangeMaterial (materialActive);
	}
		
	void ChangeToInactiveMaterial(){
		ChangeMaterial (materialInactive);
	}

	void ChangeToHoverMaterial(){
		ChangeMaterial (materialHover);
	}

	void SetColliderState(bool state){
		waypointCollider.enabled = state;
	}
}
