using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    public bool activated = false;
    public int id = 0;
    
    private NodeController nodeController;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    public Sprite sprite_off;
    public Sprite sprite_on;

    private void Awake()
    {
        nodeController = GameObject.Find("GameController").GetComponent<NodeController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
            nodeController.OnNodeActivated(this);
        
    }

}
