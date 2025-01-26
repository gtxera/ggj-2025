using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkspaceGrid : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField]
    private GridLayoutGroup _gridLayout;
    
    private WorkspaceCell[][] _grid;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        _grid = new WorkspaceCell[14][];

        for (var i = 0; i < _grid.Length; i++)
        {
            _grid[i] = new WorkspaceCell[5];
        }

        var y = 0;
        var x = 0;
        
        foreach (Transform child in transform)
        {
            var cell = child.GetComponent<WorkspaceCell>();
            _grid[x][y] = cell;
            y++;
            if (y >= _grid[0].Length)
            {
                x++;
                if (x > _grid.Length)
                    Debug.LogError("CELULAS A MAIS");
                y = 0;
            }
        }
    }

    public WorkspaceCell GetCell(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        var rect = _rectTransform.rect;

        rect.height -= _gridLayout.padding.vertical;
        rect.width -= _gridLayout.padding.horizontal;

        var x = Mathf.RoundToInt(eventData.position.x / (_gridLayout.cellSize.x + _gridLayout.spacing.x));
        var y = Mathf.RoundToInt(eventData.position.y / (_gridLayout.cellSize.y + _gridLayout.spacing.y));
        
        Debug.Log($"{x}-{y}");

        var cell = _grid[x][y];

        while (cell.IsOccuppied)
        {
            y++;
            if (y >= _grid[0].Length)
            {
                x++;
                if (x >= _grid.Length)
                {
                    x = 0;
                }
                y = 0;
            }

            cell = _grid[x][y];
        }

        return cell;
    }
}
