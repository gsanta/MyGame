
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridRenderer gridRenderer;
    [SerializeField] private GridFactory gridFactory;
    [SerializeField] private ProceduralMeshFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;
    [SerializeField] private PreviewManager previewManager;

    private RandomShapeChooser randomShapeChooser;
    private GenericGrid<GridObject> grid;

    private void Awake()
    {
        randomShapeChooser = new RandomShapeChooser(proceduralMeshFactory);
        grid = gridFactory.CreateGrid();
        gridRenderer.Construct(grid);
        dropManager.Construct(grid, gridFactory, randomShapeChooser);
        previewManager.Construct(grid, gridFactory);
        proceduralMeshFactory.Construct(grid, dropManager, previewManager);

        randomShapeChooser.ChooseShape();
    }
}
