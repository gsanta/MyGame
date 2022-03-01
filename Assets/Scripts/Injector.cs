
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridRenderer gridRenderer;
    [SerializeField] private GridFactory gridFactory;
    [SerializeField] private ProceduralMeshFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;

    private GenericGrid<GridObject> grid;

    private void Awake()
    {
        grid = gridFactory.CreateGrid();
        gridRenderer.Construct(grid);
        dropManager.Construct(grid, gridFactory, proceduralMeshFactory);
        proceduralMeshFactory.Construct(grid, dropManager);
        proceduralMeshFactory.CreateLShape();
    }
}
