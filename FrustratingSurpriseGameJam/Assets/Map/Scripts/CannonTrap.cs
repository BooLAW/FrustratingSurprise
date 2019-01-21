using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrap : TrapBaseClass
{
    public float shot_timer = 200.0f;
    private float last_shot_time = 0.0f;
    public Vector2 shot_direction = Vector2.right;
    public Object projectile;
    public int shots_until_sleep = -1;
    private int shots_taken = 0;
    

    override public void childUpdate()
    {
        if (state == TrapState.ACTIVATING && Time.time > last_shot_time + shot_timer)
        {
            GameObject shot = (GameObject)Instantiate(projectile, transform);
            shot.GetComponent<BaseShotClass>().direction = shot_direction.normalized;
            last_shot_time = Time.time;
            shots_taken++;

            if (shots_taken >= shots_until_sleep && shots_until_sleep != -1)
                childReset();
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
        state = TrapState.INACTIVE;
        shots_taken = 0;
    }

}