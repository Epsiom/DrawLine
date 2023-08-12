using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum NodeState {
    INACTIVE,
    HIGHLIGHTED,
    SELECTED,
    ACTIVE
}

public class Node : MonoBehaviour
{
    public Vector2 Coordinates;
    public NodeState NodeState = NodeState.INACTIVE;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private LineManager _lineManager;

    private GridManager _gridManager;
    private ColorSO _gridColors;

    private Color inactive_node;
    private Color highlighted_node;
    private Color selected_node;
    private Color active_node;

    public void Init(Vector2 coordinates, LineManager lineManager, GridManager gridManager, ColorSO gridColors)
    {
        Coordinates = coordinates;

        _lineManager = lineManager;
        _gridManager = gridManager;
        _gridColors = gridColors;

        inactive_node = _gridColors.getColor("inactive_node");
        highlighted_node = _gridColors.getColor("highlighted_node");
        selected_node = _gridColors.getColor("selected_node");
        active_node = _gridColors.getColor("active_node");
    }

    void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            // If the left click is dragged accross the node
            _spriteRenderer.DOColor(selected_node, 0.1f);
            transform.DOScale(1.5f, 0.1f);

            _lineManager.ClickedNode(this);
        }
        else
        {
            // If the node is simply hovered
            _spriteRenderer.DOColor(highlighted_node, 0.2f);
            transform.DOScale(1.2f, 0.2f);
        }
    }

    void OnMouseExit()
    {
        _spriteRenderer.DOColor(inactive_node, 0.2f);
        transform.DOScale(1f, 0.2f);
    }

    void OnMouseDown()
    {
        _spriteRenderer.DOColor(selected_node, 0.1f);
        transform.DOScale(1.5f, 0.1f);

        _lineManager.ClickedNode(this);
    }

    public void ChangeNodeState(NodeState newState)
    {
        NodeState = newState;
    }
}
