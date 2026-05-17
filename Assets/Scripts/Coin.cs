using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinCounter coinCounter;
    public AudioClip collectSound;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            if (coinCounter != null)
            {
                coinCounter.AddCoin();
            }

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            gameObject.SetActive(false);
        }
    }
}