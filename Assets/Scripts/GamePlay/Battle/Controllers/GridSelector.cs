using UnityEngine;

public class GridSelector : MonoBehaviour
{
    protected GenericGrid<GroundBlock> grid;
    public void SetGrid(GenericGrid<GroundBlock> grid)
    {
        this.grid = grid;
    }

    protected GroundBlock GetGroundBlockAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            if (hit.transform)
            {
                var halfCellSize = (float)grid.cellSize / 2.0f;
                var point = new Vector3(hit.point.x + halfCellSize, hit.point.y + halfCellSize, hit.point.z);
                var gridObj = grid.GetGridObject(point);

                return gridObj;
            }
        }
        return null;
    }

    protected bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }
}
