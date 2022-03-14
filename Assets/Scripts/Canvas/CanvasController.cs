using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startLevelModal;
    private BattleGridSetup battleGridSetup;
    private PuzzleManager levelGuilderSetup;
    private PlayersSetup playerSetup;
    private GenericGrid<PuzzleBlock> grid;
    public void Construct(BattleGridSetup battleGridSetup, PuzzleManager levelGuilderSetup, GenericGrid<PuzzleBlock> grid, PlayersSetup playerSetup)
    {
        this.battleGridSetup = battleGridSetup;
        this.levelGuilderSetup = levelGuilderSetup;
        this.playerSetup = playerSetup;
        this.grid = grid;
    }
    public void EndSetupLevel()
    {
        startLevelModal.SetActive(true);
    }

    public void StartLevel()
    {
        startLevelModal.SetActive(false);
        var gameGrid = battleGridSetup.Create(grid);
        levelGuilderSetup.TearDown();
        playerSetup.Setup(gameGrid);
    }
}
