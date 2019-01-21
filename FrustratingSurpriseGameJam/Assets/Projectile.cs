using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Projectile : MonoBehaviour {

    public float speed;
    private Transform player;
    private Vector2 target;
    bool first_instance = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        first_instance = (name == "Projectile");
    }
	
	// Update is called once per frame
	void Update () {
        if (first_instance)
            return;

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && !first_instance)
            DestroyProjectile();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !first_instance)
        {
            DestroyProjectile();
            SceneManager.LoadScene(SceneManager.GetSceneByName("level_0").name);

        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
