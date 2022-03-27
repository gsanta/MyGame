using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    private Dictionary<GroundBlock, GroundBlock> movements = new Dictionary<GroundBlock, GroundBlock>();
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

            var selectionComponent = groundBlock.block.GetComponent<SelectionComponent>();

            if (from != null && !groundBlock.Player)
            {
                to = groundBlock;
                selectionComponent.SetSelected(true);
            }

            if (from == null && groundBlock.Player)
            {
                from = groundBlock;
                selectionComponent.SetSelected(true);
            }

            if (from != null && to != null)
            {
                from.Player.GetComponent<MoveComponent>().SetDestination(to.block.transform.position, 2f);
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

    private void SaveMovement()
    {
        //movements.getk
    }

    //private GroundBlock GetBlock(Transform transform)
    //{
    //    return grid.GetGridObject(transform.position);
    //}

    //private bool HasPlayer(Transform transform)
    //{
    //    var gridObject = GetBlock(transform);
    //    return gridObject != null && gridObject.Player;
    //}
}
