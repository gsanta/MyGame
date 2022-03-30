using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startLevelModal;
    private BattleGridSetup battleGridSetup;
    private PuzzleManager puzzleManager;
    private PlayersSetup playerSetup;
    private GenericGrid<PuzzleBlock> grid;
    private Hover selectionController;
    public void Construct(BattleGridSetup battleGridSetup, PuzzleManager puzzleManager, GenericGrid<PuzzleBlock> grid, PlayersSetup playerSetup, Hover selectionController)
    {
        this.battleGridSetup = battleGridSetup;
        this.puzzleManager = puzzleManager;
        this.playerSetup = playerSetup;
        this.grid = grid;
        this.selectionController = selectionController;
    }
    public void EndSetupLevel()
    {
        startLevelModal.SetActive(true);
    }

    public void StartLevel()
    {
        startLevelModal.SetActive(false);
        var battleGrid = battleGridSetup.Setup(grid);
        puzzleManager.TearDown();
        playerSetup.Setup(battleGrid);
        selectionController.SetGrid(battleGrid);
    }
}
