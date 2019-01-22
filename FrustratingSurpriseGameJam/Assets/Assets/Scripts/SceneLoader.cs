using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement; 
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}

    public void LoadSceneByName(string name)
    {
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene(name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
