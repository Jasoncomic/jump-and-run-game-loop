using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 25;
    public float damageCooldown = 1f;

    private float lastDamageTime = -999f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Time.time >= lastDamageTime + damageCooldown)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastDamageTime = Time.time;
            }
        }
    }
}