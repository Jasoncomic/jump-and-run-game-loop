using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startScale;

    private Animator animator;
    private EnemyMovement enemyMovement;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startScale = transform.localScale;

        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void RespawnEnemy()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startScale;

        if (animator != null)
        {
            animator.enabled = true;
            animator.Play(0, 0, 0f);
        }

        if (enemyMovement != null)
        {
            enemyMovement.enabled = true;
        }
    }
}