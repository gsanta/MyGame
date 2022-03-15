
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
    [SerializeField] private SelectionController selectionController;

    private PuzzleManager puzzleManager;

    private GenericGrid<PuzzleBlock> grid;

    private void Awake()
    {
        grid = puzzleGridSetup.CreateGrid();
        gridLineRenderer.Construct(grid);
        dropController.Construct(grid, puzzleGridSetup);
        previewController.Construct(grid, puzzleGridSetup);
        proceduralMeshFactory.Construct(grid, dropController, previewController);
        dragController.Construct(dropController, previewController, proceduralMeshFactory, grid, canvasController);
        battleGridSetup.Construct(groundTileFactory);
        puzzleManager = new PuzzleManager(gridLineRenderer, puzzleGridSetup, dragController, puzzlePanelController, grid);
        canvasController.Construct(battleGridSetup, puzzleManager, grid, playerSetup, selectionController);
        dragController.Init();
    }
}
