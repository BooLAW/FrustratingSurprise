using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkTrap : TrapBaseClass
{
    private List<Vector2> route_positions;
    private int current_pos = 0;
    private Vector3 current_target;
    public float speed = 5.0f;

    public void Awake()
    {
        route_positions = new List<Vector2>();

        foreach (Transform child in transform)
            route_positions.Add(child.transform.position);

        state = TrapState.ACTIVE;
        current_target = route_positions[1];
        current_pos = 1;
    }

    override public void childUpdate()
    {
        if (((current_target - transform.position).normalized * speed * Time.deltaTime).magnitude < (current_target - transform.position).magnitude)
            transform.position += (current_target - transform.position).normalized * speed * Time.deltaTime;
        else
        {
            transform.position = current_target;
            if (current_pos == route_positions.Count - 1)
                current_pos = 0;
            else
                current_pos++;

            current_target = route_positions[current_pos];
        }
    }

   
    override public void childReset()
    {
        transform.position = route_positions[0];
        current_target = route_positions[1];
        current_pos = 1;
    }

}
