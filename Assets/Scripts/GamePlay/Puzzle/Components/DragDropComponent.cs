using UnityEngine;

public class DragDropComponent : MonoBehaviour
{
    private GenericGrid<PuzzleBlock> grid;
    private DropController dropController;
    private PreviewController previewController;
    private ShapeComponent shape;

    public void Construct(GenericGrid<PuzzleBlock> grid, DropController dropController, PreviewController previewController)
    {
        this.grid = grid;
        this.dropController = dropController;
        this.previewController = previewController;
        shape = GetComponent<ShapeComponent>();
        previewController.SetShape(GetComponent<ShapeComponent>());
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
        previewController.UpdatePreview();
    }

    private void OnMouseUp()
    {
        if (grid != null)
        {
            dropController.OnDrop(GetComponent<ShapeComponent>());
        }
    }
}
