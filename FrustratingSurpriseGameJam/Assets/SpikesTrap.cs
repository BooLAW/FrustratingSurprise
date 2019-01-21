using UnityEngine;
using System.Collections;

public class SpikesTrap : MonoBehaviour {

    public GameObject trap;
    Transform killzone_trans;
   
    public float max_timer_value;
    float curr_time;
    bool triggered;
    // Use this for initialization
    void Start () {
        curr_time = 0;
        triggered = false;
        trap.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(triggered)
        {
            //Start Timer & move 
            curr_time += Time.deltaTime;
        }
        if(curr_time > 0)
        {
            curr_time += Time.deltaTime;

        }
 
        if (curr_time >= max_timer_value)
        {
            //change flag and 
            triggered = false;
            curr_time = 0;
            trap.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
         triggered = true;
        trap.SetActive(true);

    }
}
