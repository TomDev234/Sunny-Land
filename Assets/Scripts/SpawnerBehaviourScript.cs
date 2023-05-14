using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviourScript : MonoBehaviour
{
    const float minimumWaitTime = 3, maximumWaitTime = 5;
    const float minimumSpeed = 1, maximumSpeed = 5;
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform leftSpawnTransform, rightSpawnTransform;
    GameObject enemy;
    int randomIndex;
    int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minimumWaitTime, maximumWaitTime));
            randomIndex = Random.Range(0, enemies.Length);
            randomSide = Random.Range(0, 2);
            enemy = Instantiate(enemies[randomIndex]);
            if (randomSide == 0)
            {
                enemy.transform.position = leftSpawnTransform.position;
                enemy.GetComponent<EnemyBehaviourScript>().speed = Random.Range(minimumSpeed, maximumSpeed);
            }
            else
            {
                enemy.transform.position = rightSpawnTransform.position;
                enemy.GetComponent<EnemyBehaviourScript>().speed = -Random.Range(minimumSpeed, maximumSpeed);
                Vector3 localScale = enemy.transform.localScale;
                enemy.transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            }
        }
    }
}
