using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private GenericGrid<GridObject> grid;
    private DropManager dropManager;

    public void Construct(GenericGrid<GridObject> grid, DropManager dropManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        var worldPoint = Camera.main.ScreenToWorldPoint(mousePoint);
        worldPoint.z = gameObject.transform.position.z;
        return worldPoint;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    public void GetDropPosition(out int x, out int y)
    {
        grid.GetXY(GetMouseWorldPos() + mOffset, out x, out y);
    }

    public void GetDropPositions(out int x, out int y)
    {
        grid.GetXY(GetMouseWorldPos() + mOffset, out x, out y);
    }

    private void OnMouseUp()
    {
        if (grid != null)
        {
            dropManager.OnDrop(this);
        }
    }
}
