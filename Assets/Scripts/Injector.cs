
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridRenderer gridRenderer;
    [SerializeField] private GridFactory gridFactory;
    [SerializeField] private ShapeFactory proceduralMeshFactory;
    [SerializeField] private DropManager dropManager;
    [SerializeField] private PreviewManager previewManager;
    [SerializeField] private DragAndDropController dragAndDropController;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GameTileFactory gameTileFactory;
    [SerializeField] private Config config;
    [SerializeField] private PlayersSetup playerSetup;
    private GameGridCreator gameGridCreator;

    private GenericGrid<Block2D> grid;

    private void Awake()
    {
        gridFactory.Construct(config);
        grid = gridFactory.CreateGrid();
        gridRenderer.Construct(grid);
        dropManager.Construct(grid, gridFactory);
        previewManager.Construct(grid, gridFactory);
        proceduralMeshFactory.Construct(grid, dropManager, previewManager);
        dragAndDropController.Construct(dropManager, previewManager, proceduralMeshFactory, grid, canvasController);
        gameGridCreator = new GameGridCreator(gridFactory, gameTileFactory);
        canvasController.Construct(gameGridCreator, grid, playerSetup);
        dragAndDropController.Init();
    }
}
