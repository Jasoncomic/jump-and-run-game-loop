using UnityEngine;

public class JewelGoal : MonoBehaviour
{
    public UIManager uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.ShowVictory();
            }

            gameObject.SetActive(false);
        }
    }
}