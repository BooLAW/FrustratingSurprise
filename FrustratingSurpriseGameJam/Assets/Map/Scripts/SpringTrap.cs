using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTrap : TrapBaseClass
{
    public Vector2 ejection_force = new Vector2(0, 1000.0f);
    private Animator m_animator;

    public void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_animator.Play("Idle");
    }

    override public void childUpdate()
    {
        if (state == TrapState.DEACTIVATING)
            state = TrapState.INACTIVE;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && state == TrapState.INACTIVE)
        {
            state = TrapState.ACTIVE;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(ejection_force);
            GetComponent<AudioSource>().Play();
            reset_timer = Time.time;
            m_animator.Play("SpringAnimation");
        }
    }

    override public void childReset()
    {
        state = TrapState.INACTIVE;
        m_animator.Play("Idle");
    }
}
