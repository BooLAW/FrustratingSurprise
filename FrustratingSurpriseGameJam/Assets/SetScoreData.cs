using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class SetScoreData : MonoBehaviour {

    public Text c_time_ui;
    public Text c_death_ui;
    public Text c_score_ui;

    public Text level_ui;

    private ScoreData score_info_script;

    // Use this for initialization
    void Start ()
    {
        score_info_script = GameObject.Find("SceneManager").GetComponent<ScoreData>();

        c_time_ui.text = score_info_script.current_time.ToString();
        c_death_ui.text = score_info_script.current_deaths.ToString();      
        level_ui.text = "LVL " + score_info_script.current_level.ToString();

        int score_this_game = (200 + (20 * score_info_script.current_level)) - ((int)score_info_script.current_time*1 + score_info_script.current_deaths*5);
        c_score_ui.text = score_this_game.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
