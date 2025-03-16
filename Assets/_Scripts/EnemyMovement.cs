using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    public Transform Player;
    public Animator animator;  // Riferimento all'Animator

    [Header("Movement Settings")]
    public float MoveSpeed = 4f;
    public float MaxDist = 10f;
    public float MinDist = 5f;
    public float AttackDistance = 1f;
    public float shuffleRadius = 3f;  // Raggio di movimento casuale
    public float shuffleInterval = 3f; // Tempo tra un movimento casuale e l'altro

    [Header("Detection Settings")]
    public LayerMask PlayerLayer;
    public float sightRange = 15f;  // Distanza massima di avvistamento del player

    private bool isShuffling = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(ShuffleMovement());
    }

    void Update()
    {
        //animator.SetTrigger("Run");
        if (CanSeePlayer())
        {
            MoveToPlayer();
        }
        else
        {
            if (!isShuffling)
            {
                animator.SetTrigger("zombie_Idle");
            }
        }
    }

    bool CanSeePlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Player.position - transform.position).normalized, out hit, sightRange, PlayerLayer))
        {
            return hit.collider.CompareTag("Player");
        }
        return false;
    }

    void MoveToPlayer()
    {
        transform.LookAt(Player);
        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance <= AttackDistance)
        {
            Attack();
        }
        else if (distance <= MaxDist)
        {
            animator.SetTrigger("zombie_Run");
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    void Attack()
    {
        animator.SetTrigger("zombie_Strike");
    }

    IEnumerator ShuffleMovement()
    {
        while (true)
        {
            if (!CanSeePlayer())
            {
                isShuffling = true;
                animator.SetTrigger("zombie_Shuffle");

                Vector3 randomDirection = new Vector3(
                    Random.Range(-shuffleRadius, shuffleRadius),
                    0,
                    Random.Range(-shuffleRadius, shuffleRadius)
                );

                Vector3 targetPosition = transform.position + randomDirection;
                transform.LookAt(targetPosition);

                float elapsedTime = 0;
                float moveDuration = 1.5f;  // Durata del movimento shuffle

                while (elapsedTime < moveDuration)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / moveDuration));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                animator.SetTrigger("zombie_Idle");
                isShuffling = false;
            }
            yield return new WaitForSeconds(shuffleInterval);
        }
    }
}
