using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private GenericGrid<Block2D> grid;
    private DropManager dropManager;
    private PreviewManager previewManager;
    private ProceduralShape shape;

    public void Construct(GenericGrid<Block2D> grid, DropManager dropManager, PreviewManager previewManager)
    {
        this.grid = grid;
        this.dropManager = dropManager;
        this.previewManager = previewManager;
        shape = GetComponent<ProceduralShape>();
        previewManager.SetShape(GetComponent<ProceduralShape>());
    }

    private void OnMouseDown()
    {
        shape.mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        shape.mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = shape.mZCoord;

        var worldPoint = Camera.main.ScreenToWorldPoint(mousePoint);
        worldPoint.z = gameObject.transform.position.z;
        return worldPoint;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + shape.mOffset;
        previewManager.UpdatePreview();
    }

    private void OnMouseUp()
    {
        if (grid != null)
        {
            dropManager.OnDrop(GetComponent<ProceduralShape>());
        }
    }
}
