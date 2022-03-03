
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private GenericGrid<GridObject> grid;
    private GridFactory gridFactory;
    private ProceduralMeshFactory meshFactory;

    public void Construct(GenericGrid<GridObject> grid, GridFactory gridFactory, ProceduralMeshFactory meshFactory)
    {
        this.grid = grid;
        this.gridFactory = gridFactory;
        this.meshFactory = meshFactory;
    }

    public void OnDrop(DragDrop dragDrop)
    {
        var positions = dragDrop.GetComponent<ProceduralShape>().GetPositions();
        foreach(var position in positions)
        {
            gridFactory.CreateTile(grid.GetWorldPosition(position.x, position.y));
        }
        
        Destroy(dragDrop.gameObject);

        meshFactory.CreateLine3Shape(ShapeDirection.Up);
    }
}
