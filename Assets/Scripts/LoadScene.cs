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

	public void LoadNewScene() {
		print ("entering new area");
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName, LoadSceneMode.Single);	
	}

	void OnEnable(){
		UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnFinishedLoading;
	}

	void OnFinishedLoading(Scene scene, LoadSceneMode mode) {
		print ("testing");
	}
}
