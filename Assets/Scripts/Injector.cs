
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridRenderer gridRenderer;
    [SerializeField] private GridFactory gridFactory;
    [SerializeField] private ProceduralMeshFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;
    [SerializeField] private PreviewManager previewManager;
    [SerializeField] private DragAndDropController dragAndDropController;

    private GenericGrid<GridObject> grid;

    private void Awake()
    {
        grid = gridFactory.CreateGrid();
        gridRenderer.Construct(grid);
        dropManager.Construct(grid, gridFactory);
        previewManager.Construct(grid, gridFactory);
        proceduralMeshFactory.Construct(grid, dropManager, previewManager);
        dragAndDropController.Construct(dropManager, previewManager, proceduralMeshFactory);
        dragAndDropController.Init();
    }
}
