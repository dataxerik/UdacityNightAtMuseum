using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadAttraction() {
		Player.Instance.UpdateLastSceneWayPoint ();
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	public void LoadHub() {
		print ("entering hub");
		SceneManager.isReturningToHub = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName, LoadSceneMode.Single);	
	}

	void OnEnable(){
		//UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnFinishedLoading;
	}

	void OnFinishedLoading(Scene scene, LoadSceneMode mode) {
		print ("testing");
	}
}
