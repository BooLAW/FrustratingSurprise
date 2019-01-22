using UnityEngine;

public class NodeController : MonoBehaviour
{
    private int current_node = 0;
    private int node_num = 0;
    GameObject[] nodes;

    public void Awake()
    {
        node_num =  GameObject.FindGameObjectsWithTag("Node").Length;
        nodes = GameObject.FindGameObjectsWithTag("Node");
        TurnOnNextNode();
    }
    
    public void OnNodeActivated(NodeBehavior node)
    {
        if (node.id == current_node)
        {
            node.activated = true;
            node.spriteRenderer.sprite = node.sprite_on;
            node.GetComponent<AudioSource>().Play();
            node.gameObject.transform.Find("Particle System").gameObject.SetActive(false);
            current_node++;

            if (current_node == node_num)
                gameObject.GetComponent<GameController>().LevelComplete();
            else
                TurnOnNextNode();
        }
    }

    private void TurnOnNextNode()
    {
        foreach (GameObject node in nodes)
        {
            if (current_node == node.GetComponent<NodeBehavior>().id)
                node.gameObject.transform.Find("Particle System").gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        foreach (GameObject node in nodes)
        {
            NodeBehavior nodeBehavior = node.GetComponent<NodeBehavior>();
            nodeBehavior.activated = false;
            nodeBehavior.spriteRenderer.sprite = nodeBehavior.sprite_off;
        }

        current_node = 0;
    }
}
