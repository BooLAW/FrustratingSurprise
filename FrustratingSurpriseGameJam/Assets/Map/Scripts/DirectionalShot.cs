using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalShot : BaseShotClass
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
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
