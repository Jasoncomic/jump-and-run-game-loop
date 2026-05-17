using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup hudCanvas;
    public CanvasGroup gameOverCanvas;
    public CanvasGroup victoryCanvas;

    public PlayerRespawn playerRespawn;
    public PlayerHealth playerHealth;
    public CoinCounter coinCounter;

    private void Start()
    {
        ShowHUD();
    }

    public void ShowHUD()
    {
        SetCanvas(hudCanvas, true);
        SetCanvas(gameOverCanvas, false);
        SetCanvas(victoryCanvas, false);

        LockCursor();
    }

    public void ShowGameOver()
    {
        SetCanvas(hudCanvas, false);
        SetCanvas(gameOverCanvas, true);
        SetCanvas(victoryCanvas, false);

        UnlockCursor();
    }

    public void ShowVictory()
    {
        SetCanvas(hudCanvas, false);
        SetCanvas(gameOverCanvas, false);
        SetCanvas(victoryCanvas, true);

        UnlockCursor();
    }

    public void RespawnButtonPressed()
    {
        if (playerHealth != null)
        {
            playerHealth.RestoreHealth();
        }

        if (playerRespawn != null)
        {
            playerRespawn.Respawn();
        }

        if (coinCounter != null)
        {
            coinCounter.ResetCoins();
        }

        ShowHUD();
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }

    private void SetCanvas(CanvasGroup canvas, bool visible)
    {
        if (canvas == null) return;

        canvas.alpha = visible ? 1f : 0f;
        canvas.interactable = visible;
        canvas.blocksRaycasts = visible;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}