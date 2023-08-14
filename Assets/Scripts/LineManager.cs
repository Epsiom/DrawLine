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

    public void Awake()
    {
        LineRenderer.startColor = GridColors.getColor("line");
        LineRenderer.endColor = GridColors.getColor("line");
    }

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
            if (IsNodeSelectionValid(clickedNode))
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

                if (_linkedNodes.Count == GridManager.GetTotalNodeCount())
                {
                    GridManager.TriggerLevelVictory();
                }
            }
        }
    }

    /***
     * Enforces the three rules for a line to be valid:
     * 1) It must not reuse a Node that is already connected to a line
     * 2) It must not be (0,0) obviously, and must only be diagonal along the adjacent column/row
     * 3) It must not be the direct continuation of the previous line
     */
    public bool IsNodeSelectionValid(Node destinationNode)
    {
        // The first node by itself is always valid since it does not make a line yet
        if (_linkedNodes.Count == 0)
        {
            return true;
        }

        // Ensures that the line cannot be connected to a Node that is already linked
        if (_linkedNodes.Contains(destinationNode))
        {
            return false;
        }

        // Ensures that the line is a diagonal along the adjacent column/row
        Vector2 startNodeCoordinates = _linkedNodes[_linkedNodes.Count - 1].Coordinates;
        Vector2 destinationNodeCoordinates = destinationNode.Coordinates;
        Vector2 lineVector = destinationNodeCoordinates - startNodeCoordinates;
        bool isLineValid = (Mathf.Abs(lineVector.x) == 1 && lineVector.y != 0) || (lineVector.x != 0 && Mathf.Abs(lineVector.y) == 1);
        
        if (_linkedNodes.Count == 1)
        {
            return isLineValid;
        }
        else
        {
            // Ensure the next line is not the direct continuation of the previous line
            Vector2 previousStartNodeCoordinates = _linkedNodes[_linkedNodes.Count - 2].Coordinates;
            Vector2 previousDestinationNodeCoordinates = _linkedNodes[_linkedNodes.Count - 1].Coordinates;
            Vector2 previousLineVector = previousDestinationNodeCoordinates - previousStartNodeCoordinates;
            return isLineValid && (lineVector != previousLineVector);
        }
    }

    public void Reset()
    {
        _selectedNode = null;
        _linkedNodes.Clear();
        LineRenderer.positionCount = 0;
    }
}
