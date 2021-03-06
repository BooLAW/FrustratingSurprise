﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapState { INACTIVE, ACTIVATING, ACTIVE, DEACTIVATING }

public abstract class TrapBaseClass : MonoBehaviour {
    
    public float reset_timer = 0.0f;
    public float reset_time = 1000.0f;
    public bool collider_kills = true;

    public TrapState state = TrapState.INACTIVE;
    
	// Update is called once per frame
	void Update () {
        childUpdate();
        
        if(state == TrapState.ACTIVE)
        {
            if (Time.time > reset_time + reset_timer)
            {
                state = TrapState.DEACTIVATING;
                reset_timer = Time.time;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player" && collider_kills)
        {
            col.gameObject.GetComponent<PlayerController>().Die();
        }
    }
    

    public virtual void Reset() { childReset(); }
    public virtual void childReset() { }
    public virtual void childUpdate() { }

    
}
