using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatformTrap : TrapBaseClass
{
    public float min_size = 0.1f;
    public float shrinking_time = 3.0f;
    private float activation_time = 0.0f;
    private Vector2 center;

    override public void childUpdate()
    {
        if (state == TrapState.ACTIVATING)
        {
            if ((Time.time - activation_time) > shrinking_time)
            {
                transform.parent.localScale = new Vector2(min_size, min_size);
                state = TrapState.ACTIVE;
                reset_timer = Time.time;
            }
            else
            {
                float size = Mathf.Lerp(1.0f, min_size, (Time.time - activation_time) / shrinking_time);
                transform.parent.localScale = new Vector2(size, size);
            }
        }
        else if (state == TrapState.DEACTIVATING)
        {
            if ((Time.time - reset_timer) > shrinking_time)
            {
                transform.parent.localScale = new Vector2(1.0f, 1.0f);
                state = TrapState.INACTIVE;
            }
            else
            {
                float size = Mathf.Lerp(min_size, 1.0f, (Time.time - reset_timer) / shrinking_time);
                transform.parent.localScale = new Vector2(size, size);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && state == TrapState.INACTIVE)
        {
            state = TrapState.ACTIVATING;
            activation_time = Time.time;
        }
    }

    override public void childReset()
    {
        transform.parent.localScale = new Vector2(1.0f, 1.0f);
        state = TrapState.INACTIVE;
    }

}