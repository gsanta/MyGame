public class PuzzleManager
{
    private GridLineRenderer gridLineRenderer;
    private PuzzleGridSetup puzzleGridSetup;
    private GenericGrid<PuzzleBlock> grid;
    private DragController dragController;

    public PuzzleManager(GridLineRenderer gridLineRenderer, PuzzleGridSetup puzzleGridSetup, DragController dragController, GenericGrid<PuzzleBlock> grid)
    {
        this.gridLineRenderer = gridLineRenderer;
        this.puzzleGridSetup = puzzleGridSetup;
        this.dragController = dragController;
        this.grid = grid;
    }

    public void TearDown()
    {
        puzzleGridSetup.DestroyGrid(grid);
        gridLineRenderer.DestroyGridLines();
        dragController.DisableController();
    }
}
