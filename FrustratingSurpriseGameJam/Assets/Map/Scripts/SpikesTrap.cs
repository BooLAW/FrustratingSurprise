using UnityEngine;
using System.Collections;

public class SpikesTrap : TrapBaseClass {
    
    public Vector2 displacement = Vector2.zero;
    public float displacement_time = 3.0f;
    private Vector2 starting_position = Vector2.zero;
    private float activation_time = 0.0f;
    private Animator m_animator;
    
    public void Awake()
    {
        starting_position = transform.position;
        m_animator = GetComponent<Animator>();
        m_animator.Play("Idle");
    }

    override public void childUpdate()
    {
        if (state == TrapState.ACTIVATING)
        {
            if ((Time.time - activation_time) >  displacement_time)
            {
                transform.position = starting_position + displacement;
                state = TrapState.ACTIVE;
                reset_timer = Time.time;
            }
            else
                transform.position = Vector2.Lerp(starting_position, starting_position + displacement, (Time.time - activation_time) / displacement_time);
        }
        else if (state == TrapState.DEACTIVATING)
        {
            if ((Time.time - reset_timer) >  displacement_time)
            {
                transform.position = starting_position;
                state = TrapState.INACTIVE;
                m_animator.Play("Idle");
            }
            else
                transform.position = Vector2.Lerp(starting_position + displacement, starting_position, (Time.time - reset_timer) / displacement_time);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && state == TrapState.INACTIVE)
        {
            state = TrapState.ACTIVATING;
            activation_time = Time.time;
            m_animator.Play("SpikeAnim");
        }
    }

    override public void childReset()
    {
        transform.position = starting_position;
        state = TrapState.INACTIVE;
        m_animator.Play("Idle");
    }
    
}
