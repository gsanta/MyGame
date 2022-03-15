public class PuzzleManager
{
    private GridLineRenderer gridLineRenderer;
    private PuzzleGridSetup puzzleGridSetup;
    private GenericGrid<PuzzleBlock> grid;
    private DragController dragController;
    private PuzzlePanelController puzzlePanelController;

    public PuzzleManager(GridLineRenderer gridLineRenderer, PuzzleGridSetup puzzleGridSetup, DragController dragController, PuzzlePanelController puzzlePanelController, GenericGrid<PuzzleBlock> grid)
    {
        this.gridLineRenderer = gridLineRenderer;
        this.puzzleGridSetup = puzzleGridSetup;
        this.dragController = dragController;
        this.puzzlePanelController = puzzlePanelController;
        this.grid = grid;
    }

    public void TearDown()
    {
        puzzleGridSetup.DestroyGrid(grid);
        gridLineRenderer.DestroyGridLines();
        dragController.DisableController();
        puzzlePanelController.HidePanels();
    }
}
