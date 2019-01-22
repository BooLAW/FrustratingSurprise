using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {
    
    public void Reset()
    {
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");

        foreach (GameObject trap in traps)
        {
            if(trap.GetComponent<TrapBaseClass>())
                trap.GetComponent<TrapBaseClass>().Reset();
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");


        foreach (GameObject projectile in projectiles)
            Destroy(projectile);

    }
}
