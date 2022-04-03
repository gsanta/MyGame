
using UnityEngine;

class Injector : MonoBehaviour
{
    [SerializeField] private GridLineRenderer gridLineRenderer;
    [SerializeField] private PuzzleGridSetup puzzleGridSetup;
    [SerializeField] private PuzzlePanelController puzzlePanelController;
    [SerializeField] private ShapeFactory proceduralMeshFactory;
    [SerializeField] private DropController dropController;
    [SerializeField] private PreviewController previewController;
    [SerializeField] private DragController dragController;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private GroundTileFactory groundTileFactory;
    [SerializeField] private BattleGridSetup battleGridSetup;
    [SerializeField] private PlayersSetup playerSetup;
    [SerializeField] private Hover hover;
    [SerializeField] private SelectDestinationWithMouseTask selectDestinationWithMouseTask;
    [SerializeField] private SelectPlayerWithMouseTask selectPlayerWithMouseTask;
    [SerializeField] private DelayTask delayTask;
    [SerializeField] private SurfaceComponent surfaceComponent;

    private BattleTask battleTask;
    private MovementStore movementStore;
    private MovePlayerTask movePlayerTask;
    private GridStore gridStore;

    private PuzzleManager puzzleManager;

    private GenericGrid<PuzzleBlock> grid;

    private void Awake()
    {
        gridStore = new GridStore();
        movementStore = new MovementStore();
        battleTask = new BattleTask();

        grid = puzzleGridSetup.CreateGrid();
        gridLineRenderer.Construct(grid);
        dropController.Construct(grid, puzzleGridSetup);
        previewController.Construct(grid, puzzleGridSetup);
        proceduralMeshFactory.Construct(grid, dropController, previewController);
        dragController.Construct(dropController, previewController, proceduralMeshFactory, grid, canvasController);
        battleGridSetup.Construct(groundTileFactory, surfaceComponent, gridStore);
        puzzleManager = new PuzzleManager(gridLineRenderer, puzzleGridSetup, dragController, puzzlePanelController, grid);
        canvasController.Construct(battleGridSetup, puzzleManager, grid, playerSetup, battleTask);
        dragController.Init();

        hover.Construct(gridStore);
        selectDestinationWithMouseTask.Construct(movementStore, gridStore);
        selectPlayerWithMouseTask.Construct(movementStore, gridStore);

        movePlayerTask = new MovePlayerTask(movementStore);

        battleTask.SubTasks(new ITask[] { movePlayerTask });
        movePlayerTask.SubTasks(new ITask[] { selectPlayerWithMouseTask, delayTask, selectDestinationWithMouseTask });
    }
}
