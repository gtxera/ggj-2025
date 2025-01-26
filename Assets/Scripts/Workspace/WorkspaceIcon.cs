using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkspaceIcon : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private CanvasGroup _group;
    private RectTransform _rectTransform;
    private WorkspaceGrid _grid;
    
    private void Start()
    {
        _canvas = FindAnyObjectByType<Canvas>();
        _grid = FindAnyObjectByType<WorkspaceGrid>();
        _group = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }


    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _group.alpha = 0.6f;
        _rectTransform.SetParent(_canvas.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _group.alpha = 1f;

        _grid.GetCell(eventData).TrySetIcon(this);
        _rectTransform.anchoredPosition = Vector2.zero;
    }
}
