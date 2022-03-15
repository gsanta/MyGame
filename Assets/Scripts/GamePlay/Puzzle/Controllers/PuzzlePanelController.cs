using UnityEngine;

public class PuzzlePanelController : MonoBehaviour
{
    [SerializeField] private GameObject puzzlePanel;

    public void HidePanels()
    {
        puzzlePanel.SetActive(false);
    }

    public void ShowPanels()
    {
        puzzlePanel.SetActive(true);
    }
}
