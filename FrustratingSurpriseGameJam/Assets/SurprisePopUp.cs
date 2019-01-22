using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurprisePopUp : MonoBehaviour {

    private PlayerController player;
    public int death_count;
    private int prev_death_count;
    private Text m_text;
    private int frame;
	// Use this for initialization
	void Start () {
       player =  GameObject.Find("Player").GetComponent<PlayerController>();
        death_count = player.death_count;
        prev_death_count = death_count;
        m_text = GetComponent<Text>();
        frame = 0;
        StartCoroutine(Example());

    }
 
    // Update is called once per frame
    void Update() {

        if (prev_death_count != death_count)
        {
            m_text.enabled = !m_text.enabled;
            prev_death_count = death_count;
        }
        if(m_text.enabled)
        {
            if (frame <= 100)
            {
                frame++;
            }
            else
            {
                frame = 0;
                m_text.enabled = false;
            }
        }
        death_count = player.death_count;

    }
    IEnumerator Example()
    {
        yield return new WaitUntil(() => frame >= 100);
    }
}
