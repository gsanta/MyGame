using UnityEngine;

public class SelectionController : MonoBehaviour
{
    private GroundBlock from;
    private GroundBlock to;
    private GenericGrid<GroundBlock> grid;
    private SelectionComponent hovered;
    public void SetGrid(GenericGrid<GroundBlock> grid)
    {
        this.grid = grid;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var groundBlock = GetGroundBlockAtMousePosition();

            if (groundBlock == null)
            {
                return;
            }

            if (groundBlock.Item && groundBlock.Item.isEnemy)
            {
                return;
            }

            var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

            if (from != null && !groundBlock.Item)
            {
                to = groundBlock;
                selectionComponent.SetSelected(true);
            }

            if (from == null && groundBlock.Item)
            {
                from = groundBlock;
                selectionComponent.SetSelected(true);
            }

            if (from != null && to != null)
            {
                from.Item.GetComponent<MoveComponent>().SetDestination(to.block.transform.position, 2f);
                from.block.GetComponent<SelectionComponent>().SetSelected(false);
                to.block.GetComponent<SelectionComponent>().SetSelected(false);
                from = null;
                to = null;
            }
        }

        if (HasMouseMoved())
        {
            var groundBlock = GetGroundBlockAtMousePosition();

            if (groundBlock == null)
            {
                RemoveHover();
                return;
            }

            var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

            if (!selectionComponent.IsHovered)
            {
                RemoveHover();
                selectionComponent.SetHovered(true);
                hovered = selectionComponent;
            }
        }
    }

    private void RemoveHover()
    {
        if (hovered)
        {
            hovered.SetHovered(false);
            hovered = null;
        }
    }

    private GroundBlock GetGroundBlockAtMousePosition()
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

    private bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }
}
