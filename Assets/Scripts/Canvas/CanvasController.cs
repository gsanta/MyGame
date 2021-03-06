using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startLevelModal;
    private BattleGridSetup battleGridSetup;
    private PuzzleManager puzzleManager;
    private PlayersSetup playerSetup;
    private GenericGrid<PuzzleBlock> grid;
    private BattleTask battleTask;

    public void Construct(BattleGridSetup battleGridSetup, PuzzleManager puzzleManager, GenericGrid<PuzzleBlock> grid, PlayersSetup playerSetup, BattleTask battleTask)
    {
        this.battleGridSetup = battleGridSetup;
        this.puzzleManager = puzzleManager;
        this.playerSetup = playerSetup;
        this.grid = grid;
        this.battleTask = battleTask;
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
        battleTask.SetActive(true);
    }
}
