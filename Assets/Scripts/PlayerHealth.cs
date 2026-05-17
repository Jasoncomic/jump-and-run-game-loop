using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public UIManager uiManager;
    public PlayerMovement playerMovement;
    public TMP_Text healthText;

    private CharacterController characterController;
    private Renderer[] playerRenderers;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        // Gets all visible mesh renderers from the Mage and its children
        playerRenderers = GetComponentsInChildren<Renderer>();
    }

    private void Start()
    {
        UpdateHealthText();
        SetPlayerVisible(true);
    }

    private void Update()
    {
        // Temporary test key
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(999);
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead()) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateHealthText();
            Die();
            return;
        }

        UpdateHealthText();
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthText();

        SetPlayerVisible(true);

        if (characterController != null)
        {
            characterController.enabled = true;
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }

    public void SetHealthToZero()
    {
        currentHealth = 0;
        UpdateHealthText();
        Die();
    }

    private void Die()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (characterController != null)
        {
            characterController.enabled = false;
        }

        SetPlayerVisible(false);

        if (uiManager != null)
        {
            uiManager.ShowGameOver();
        }
    }

    private void SetPlayerVisible(bool visible)
    {
        foreach (Renderer renderer in playerRenderers)
        {
            if (renderer != null)
            {
                renderer.enabled = visible;
            }
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "%";
        }
    }
}