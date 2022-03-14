
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridLineRenderer gridLineRenderer;
    [SerializeField] private LevelGridSetup levelGridSetup;
    [SerializeField] private ShapeFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;
    [SerializeField] private PreviewManager previewManager;
    [SerializeField] private DragAndDropController dragAndDropController;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GameTileFactory gameTileFactory;
    [SerializeField] private GameGridSetup gameGridSetup;
    [SerializeField] private PlayersSetup playerSetup;

    private GenericGrid<Block2D> grid;

    private void Awake()
    {
        grid = levelGridSetup.CreateGrid();
        gridLineRenderer.Construct(grid);
        dropManager.Construct(grid, levelGridSetup);
        previewManager.Construct(grid, levelGridSetup);
        proceduralMeshFactory.Construct(grid, dropManager, previewManager);
        dragAndDropController.Construct(dropManager, previewManager, proceduralMeshFactory, grid, canvasController);
        gameGridSetup.Construct(gameTileFactory);
        canvasController.Construct(gameGridSetup, levelGridSetup, grid, playerSetup);
        dragAndDropController.Init();
    }
}
