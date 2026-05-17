using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    public int damage = 25;
    public float damageCooldown = 1f;

    private float lastDamageTime = -999f;

    private void OnTriggerEnter(Collider other)
    {
        DamagePlayer(other);
    }

    private void OnTriggerStay(Collider other)
    {
        DamagePlayer(other);
    }

    private void DamagePlayer(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Time.time < lastDamageTime + damageCooldown) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            lastDamageTime = Time.time;
            Debug.Log("Saw damaged player");
        }
    }
}