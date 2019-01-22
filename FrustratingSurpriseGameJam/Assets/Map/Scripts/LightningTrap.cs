using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrap : TrapBaseClass
{
    private BoxCollider2D death_collider;
    private SpriteRenderer spriteRenderer;
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        foreach (BoxCollider2D col in colliders)
        {
            if (!col.isTrigger)
            {
                death_collider = col;
                return;
            }
        }      
    }

    override public void childUpdate()
    {
        if (state == TrapState.ACTIVATING)
        {
            GetComponent<AudioSource>().Play();
            death_collider.enabled = true;
            spriteRenderer.enabled = true;
            state = TrapState.ACTIVE;
            reset_timer = Time.time;

        }
        else if (state == TrapState.DEACTIVATING)
        {
            GetComponent<AudioSource>().Stop();
            death_collider.enabled = false;
            spriteRenderer.enabled = false;
            state = TrapState.INACTIVE;
            reset_timer = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && state == TrapState.INACTIVE)
        {
            state = TrapState.ACTIVATING;
        }
    }

    override public void childReset()
    {
        death_collider.enabled = false;
        spriteRenderer.enabled = false;
        state = TrapState.INACTIVE;
    }

}
