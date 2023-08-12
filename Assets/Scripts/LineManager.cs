using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public GridManager GridManager;
    public ColorSO GridColors;

    private List<Node> _linkedNodes = new List<Node>();
    private Node _selectedNode;

    public void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            if (_selectedNode != null)
            {
                // Get the position of the player's finger
                Vector3 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Draw a line between the current dot and the finger position
                LineRenderer.SetPosition(LineRenderer.positionCount-1, new Vector3(fingerPos.x, fingerPos.y, 0));
            }
        }
        */
    }

    public void ClickedNode(Node clickedNode)
    {
        if (clickedNode != _selectedNode)
        {
            // For the first iteration
            /*if (_selectedNode == null)
            {
                LineRenderer.positionCount = 2;
                LineRenderer.SetPosition(0, clickedNode.gameObject.transform.position);
                _selectedNode = clickedNode;
                return;
            }
            */
            if (IsLineValid(clickedNode))
            {
                _linkedNodes.Add(clickedNode);
                if (_selectedNode != null)
                {
                    _selectedNode.ChangeNodeState(NodeState.ACTIVE);
                }
                clickedNode.ChangeNodeState(NodeState.SELECTED);
                LineRenderer.positionCount += 1;
                LineRenderer.SetPosition(_linkedNodes.Count-1, clickedNode.gameObject.transform.position);
                _selectedNode = clickedNode;
            }
        }
    }

    public bool IsLineValid(Node destinationNode)
    {
        //TODO

        return true;
    }
}
