
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridRenderer gridRenderer;
    [SerializeField] private GridFactory gridFactory;
    [SerializeField] private ProceduralMeshFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;

    private RandomShapeChooser randomShapeChooser;
    private GenericGrid<GridObject> grid;

    private void Awake()
    {
        randomShapeChooser = new RandomShapeChooser(proceduralMeshFactory);
        grid = gridFactory.CreateGrid();
        gridRenderer.Construct(grid);
        dropManager.Construct(grid, gridFactory, randomShapeChooser);
        proceduralMeshFactory.Construct(grid, dropManager);

        randomShapeChooser.ChooseShape();
    }
}
