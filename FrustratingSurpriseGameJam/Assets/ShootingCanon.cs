using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCanon : MonoBehaviour {

    private float timeBtWShots;
    public float startTimeBtWShots;
    public GameObject projectile;
    private Transform player;
    bool first_instance = false;
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        first_instance = (name == "Projectile");

    }

    // Update is called once per frame
    void Update () {
        if (first_instance)
            return;
		if(timeBtWShots <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtWShots = startTimeBtWShots;
        }
        else
        {
            timeBtWShots -= Time.deltaTime;
        }
	}
}
