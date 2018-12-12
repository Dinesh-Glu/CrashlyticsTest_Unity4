using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			var dependencyStatus = task.Result;
			if (dependencyStatus == Firebase.DependencyStatus.Available) {
				// Create and hold a reference to your FirebaseApp, i.e.
				var app = Firebase.FirebaseApp.DefaultInstance;
			} else {
				UnityEngine.Debug.LogError(System.String.Format(
					"Could not resolve all Firebase dependencies: {0}", dependencyStatus)
				);
				// Firebase Unity SDK is not safe to use here.
			}
		});
	}
	
	void OnGUI()
	{
		if (GUI.Button (new Rect (100, 100, 100, 100), "Crash"))
			throw new System.Exception ("Crash test");
	}
}
