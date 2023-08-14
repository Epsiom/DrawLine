using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width = 4;                // Number of nodes horizontally
    [SerializeField] private int _height = 4;               // Number of nodes vertically
    [SerializeField] private float _nodeInterspace = 4f;    // Impacts space between the nodes
    [SerializeField] private Node _nodePrefab;
    [SerializeField] private ColorSO _gridColors;
    [SerializeField] private LineManager _lineManager;

    private Dictionary<Vector2, Node> _grid = new Dictionary<Vector2, Node>();
    private float _gridMiddleX;
    private float _gridMiddleY;

    // Start is called before the first frame update
    public void Start()
    {
        _gridMiddleX = ((float)_width - 1 + (_width - 1) * _nodeInterspace) / 2;
        _gridMiddleY = ((float)_height - 1 + (_height - 1) * _nodeInterspace) / 2;
        for (int x=0; x<_width; x++)
        {
            for (int y=0; y<_height; y++)
            {
                Node spawnedNode = Instantiate(_nodePrefab, new Vector3(x+x*_nodeInterspace - _gridMiddleX, y+y*_nodeInterspace - _gridMiddleY, 0), Quaternion.identity);     // Instantiates the node
                Vector2 coordinates = new Vector2(x, y);
                spawnedNode.name = $"Node {x} {y}";
                spawnedNode.Init(coordinates, _lineManager, this, _gridColors);
                spawnedNode.transform.SetParent(gameObject.transform);      // Makes the nodes the children of the grid

                _grid[coordinates] = spawnedNode;                                                                                               // Adds the Node to the dictionnary
            }
        }
        //TODO: reduce node interspace on bigger grids
    }

    public void TriggerLevelVictory()
    {
        //TODO
        Debug.Log("VICTORY");
        Reset();
    }

    public void Reset()
    {
        _lineManager.Reset();
        foreach (Node node in _grid.Values)
        {
            node.ChangeNodeState(NodeState.INACTIVE);
        }
    }

    public int GetTotalNodeCount()
    {
        return _grid.Count;
    }

    private Vector3 GetNodeCoordinates(int x, int y)
    {
        return new Vector3(x + x * _nodeInterspace - _gridMiddleX, y + y * _nodeInterspace - _gridMiddleY, 0);
    }
}
