using System.Collections;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject theEnemy;          // Prefab del nemico
    public int maxEnemies = 10;          // Numero massimo di nemici

    [Header("Spawn Area")]
    public Vector2 spawnMin = new Vector2(1, 1);  // Minima area di spawn (da Inspector)
    public Vector2 spawnMax = new Vector2(50, 31); // Massima area di spawn (da Inspector)

    [Header("Ground Detection")]
    public LayerMask groundLayer;        // Layer del terreno
    public float raycastHeight = 10f;    // Altezza da cui parte il Raycast
    public int maxAttempts = 20;         // Numero massimo di tentativi per trovare un punto valido

    private int enemyCount = 0;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxEnemies)
        {
            bool validSpawn = false;
            int attempts = 0;

            while (!validSpawn && attempts < maxAttempts)
            {
                // Genera coordinate casuali nel range definito da spawnMin e spawnMax
                float xPos = Random.Range(spawnMin.x, spawnMax.x);
                float zPos = Random.Range(spawnMin.y, spawnMax.y);
                Vector3 spawnPosition = new Vector3(xPos, raycastHeight, zPos); // Parte sopra il terreno

                // Raycast verso il basso per controllare il terreno
                if (Physics.Raycast(spawnPosition, Vector3.down, out RaycastHit hit, raycastHeight * 2f, groundLayer))
                {
                    Instantiate(theEnemy, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    validSpawn = true;
                    enemyCount += 1;
                }
                attempts++;
            }

            yield return new WaitForSeconds(0.1f); // Ritardo tra gli spawn
        }
    }
}
