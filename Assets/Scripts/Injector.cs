
using Battle;
using Puzzle;
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
    [SerializeField] private GroundFactory battleGroundFactory;
    [SerializeField] private BattleGridSetup battleGridSetup;
    [SerializeField] private PlayersSetup playerSetup;
    [SerializeField] private Hover hover;
    [SerializeField] private SelectDestinationWithMouseTask selectDestinationWithMouseTask;
    [SerializeField] private SelectPlayerWithMouseTask selectPlayerWithMouseTask;
    [SerializeField] private DelayTask delayTask;
    [SerializeField] private SurfaceComponent surfaceComponent;
    [SerializeField] private Puzzle.GroundFactory groundFactory;
    [SerializeField] private ItemFactory itemFactory;

    private SelectEnemyTask selectEnemyTask;
    private SelectEnemyPathTask selectEnemyPathTask;
    private BattleTask battleTask;
    private MovementStore movementStore;
    private CharacterStore characterStore;
    private TeamStore teamStore;
    private CompositeTask moveCharacterTask;
    private CompositeTask enemyTurnTask;
    private MovePlayerTask movePlayerTask;
    private MovePlayerTask moveEnemyTask;
    private GridStore gridStore;

    private PuzzleManager puzzleManager;

    private GenericGrid<PuzzleBlock> grid;

    private void Awake()
    {
        gridStore = new GridStore();
        movementStore = new MovementStore();
        characterStore = new CharacterStore();
        teamStore = new TeamStore();
        battleTask = new BattleTask();

        grid = puzzleGridSetup.CreateGrid();
        gridLineRenderer.Construct(grid);
        dropController.Construct(grid, puzzleGridSetup, groundFactory);
        previewController.Construct(grid, puzzleGridSetup);
        proceduralMeshFactory.Construct(grid, dropController, previewController, groundFactory);
        dragController.Construct(dropController, previewController, proceduralMeshFactory, grid, canvasController);
        battleGridSetup.Construct(battleGroundFactory, surfaceComponent, gridStore);
        puzzleManager = new PuzzleManager(gridLineRenderer, puzzleGridSetup, dragController, puzzlePanelController, grid);

        playerSetup.Construct(characterStore, itemFactory);
        canvasController.Construct(battleGridSetup, puzzleManager, grid, playerSetup, battleTask);
        dragController.Init();

        hover.Construct(gridStore);
        selectDestinationWithMouseTask.Construct(movementStore, gridStore);
        selectPlayerWithMouseTask.Construct(movementStore, gridStore, teamStore);

        movePlayerTask = new MovePlayerTask(movementStore);
        moveCharacterTask = new CompositeTask();

        selectEnemyTask = new SelectEnemyTask(characterStore);
        selectEnemyPathTask = new SelectEnemyPathTask(gridStore, characterStore, movementStore);
        enemyTurnTask = new CompositeTask();
        moveEnemyTask = new MovePlayerTask(movementStore);
        enemyTurnTask.SubTasks(new ITask[] { selectEnemyTask, selectEnemyPathTask, moveEnemyTask });

        battleTask.SubTasks(new ITask[] { moveCharacterTask, enemyTurnTask });
        moveCharacterTask.SubTasks(new ITask[] { selectPlayerWithMouseTask, delayTask, selectDestinationWithMouseTask, movePlayerTask });
    }
}
