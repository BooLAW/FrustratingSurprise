using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapState { INACTIVE, ACTIVATING, ACTIVE, DEACTIVATING }

public abstract class TrapBaseClass : MonoBehaviour {
    
    public float reset_timer = 0.0f;
    public float reset_time = 1000.0f;

    public TrapState state = TrapState.INACTIVE;
    
	// Update is called once per frame
	void Update () {
        childUpdate();
        
        if(state == TrapState.ACTIVE)
        {
            reset_timer += Time.deltaTime;
            if (reset_timer > reset_time)
                state = TrapState.DEACTIVATING;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Die();
        }
    }
    

    public virtual void Reset() { childReset(); }
    public virtual void childReset() { }
    public virtual void childUpdate() { }

    
}
