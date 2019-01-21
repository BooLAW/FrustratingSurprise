using UnityEngine;

public class NodeController : MonoBehaviour
{
    private int current_node = 0;
    
    public void OnNodeActivated(NodeBehavior node)
    {
        if (node.id == current_node)
        {
            node.activated = true;
            current_node++;
        }
    }

    public void Reset()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");

        foreach (GameObject node in nodes)
            node.GetComponent<NodeBehavior>().activated = false;

        current_node = 0;
    }
}
