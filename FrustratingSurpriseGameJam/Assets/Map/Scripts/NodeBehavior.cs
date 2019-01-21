using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
    public bool activated = false;
    public int id = 0;
    
    private NodeController nodeController;

    private void Awake()
    {
        nodeController = GameObject.Find("GameController").GetComponent<NodeController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
            nodeController.OnNodeActivated(this);
    }

}
