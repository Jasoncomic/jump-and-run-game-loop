using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform currentRespawnPoint;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Respawn()
    {
        if (currentRespawnPoint == null)
        {
            Debug.LogWarning("No respawn point assigned.");
            return;
        }

        if (characterController != null)
        {
            characterController.enabled = false;
            transform.position = currentRespawnPoint.position;
            characterController.enabled = true;
        }
        else
        {
            transform.position = currentRespawnPoint.position;
        }

        RespawnEnemies();
    }

    private void RespawnEnemies()
    {
        EnemyRespawn[] enemies = FindObjectsOfType<EnemyRespawn>(true);

        foreach (EnemyRespawn enemy in enemies)
        {
            enemy.RespawnEnemy();
        }
    }

    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        currentRespawnPoint = newRespawnPoint;
    }
}