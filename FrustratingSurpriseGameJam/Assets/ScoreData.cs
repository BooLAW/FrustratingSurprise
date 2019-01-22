using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int current_level; 

    public int total_score;
    public int total_deaths;
    public float total_time;

    public int current_score;
    public int current_deaths;
    public float current_time;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SetCurrentDeaths(int deaths)
    {
        current_deaths = deaths;
        total_deaths += current_deaths; 
    }

    void SetCurrentTime(float time)
    {
        current_time = time;
        total_time += current_time;
    }

    void SetCurrentScore(int score)
    {
        current_score = score;
        total_score += current_score;
    }
}
   
