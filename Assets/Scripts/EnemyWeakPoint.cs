using UnityEngine;
using System.Collections;

public class EnemyWeakPoint : MonoBehaviour
{
    public GameObject enemyObject;
    public ParticleSystem smokeParticles;
    public AudioSource audioSource;
    public AudioClip defeatSound;

    private bool defeated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (defeated) return;
        if (!other.CompareTag("Player")) return;

        defeated = true;
        StartCoroutine(DefeatEnemy());
    }

    private IEnumerator DefeatEnemy()
    {
        if (audioSource != null && defeatSound != null)
        {
            audioSource.PlayOneShot(defeatSound);
        }

        if (smokeParticles != null && enemyObject != null)
        {
            smokeParticles.transform.position = enemyObject.transform.position + Vector3.up * 0.5f;
            smokeParticles.Play();
        }

        yield return new WaitForSeconds(0.15f);

        if (enemyObject != null)
        {
            enemyObject.SetActive(false);
        }
    }
}