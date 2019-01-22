using UnityEngine;

public class NodeController : MonoBehaviour
{
    private int current_node = 0;
    private int node_num = 0;

    public void Awake()
    {
        node_num =  GameObject.FindGameObjectsWithTag("Node").Length;
    }
    
    public void OnNodeActivated(NodeBehavior node)
    {
        if (node.id == current_node)
        {
            node.activated = true;
            node.spriteRenderer.sprite = node.sprite_on;
            node.GetComponent<AudioSource>().Play();
            current_node++;

            if (current_node == node_num)
                gameObject.GetComponent<GameController>().LevelComplete();
        }
    }

    public void Reset()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject node in nodes)
        {
            NodeBehavior nodeBehavior = node.GetComponent<NodeBehavior>();
            nodeBehavior.activated = false;
            nodeBehavior.spriteRenderer.sprite = nodeBehavior.sprite_off;
        }

        current_node = 0;
    }
}
