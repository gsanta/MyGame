using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    private Dictionary<GroundBlock, GroundBlock> movements = new Dictionary<GroundBlock, GroundBlock>();
    private GenericGrid<GroundBlock> grid;
    public void SetGrid(GenericGrid<GroundBlock> grid)
    {
        this.grid = grid;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("Ground");
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                if (hit.transform)
                {
                    var selectionComponent = hit.transform.GetComponent<SelectionComponent>();
                    selectionComponent.SetSelected(!selectionComponent.IsSelected);
                    Debug.Log("has player: " + HasPlayer(hit.transform));
                }
            }
        }
    }

    private bool HasPlayer(Transform transform)
    {
        int x, y;
        var gridObject = grid.GetGridObject(transform.position);
        return gridObject != null && gridObject.Player;
    }
}
