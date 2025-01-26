using System;
using UnityEngine;

public class WorkspaceCell : MonoBehaviour
{
    private WorkspaceIcon _icon;

    public bool IsOccuppied => _icon != null;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<WorkspaceIcon>(out var icon))
            {
                _icon = icon;
                break;
            }
        }
    }

    public bool TrySetIcon(WorkspaceIcon icon)
    {
        if (IsOccuppied)
        {
            return false;
        }

        _icon = icon;
        _icon.transform.SetParent(transform);

        return true;
    }
}
