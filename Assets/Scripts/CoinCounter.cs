using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinText;

    private void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    public void ResetCoins()
    {
        coins = 0;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}