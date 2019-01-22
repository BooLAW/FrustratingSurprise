using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement; 
using UnityEngine;

public class SceneLoader : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    public void LoadSceneByName(string name)
    {
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Debug.Log("fdkjhsdf");
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
