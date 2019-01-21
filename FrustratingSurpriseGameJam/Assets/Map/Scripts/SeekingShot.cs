using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingShot : BaseShotClass
{

    public float speed = 10.0f;
    private GameObject player;
    public float seeking_range = 10.0f;

	void Awake () {
        player = GameObject.Find("Player");
	}


    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < seeking_range)
        {
            Vector2 desired_direction = (player.transform.position - transform.position).normalized;
            direction = Vector2.Lerp(direction, desired_direction, 0.5f * Time.deltaTime * (seeking_range / (player.transform.position - transform.position).magnitude)).normalized;
        }

        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x > 50 || transform.position.x < -50 || transform.position.y > 50 || transform.position.y < -50)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
            Destroy(gameObject);
        }
    }

}
