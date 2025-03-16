using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;
    int AttackDistance = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            
        }
    }

    void MoveToPlayer()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            //Idleanimation
            
        }
        else if (Vector3.Distance(transform.position, Player.position) <= AttackDistance)
        {
            Attack();
        }
        else if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
    }

    void Attack()
    {

    }
}
