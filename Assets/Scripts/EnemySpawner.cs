using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject safeAreaCube;
    [SerializeField] Transform tower_target;
    [SerializeField] EnemySO[] enemyScriptableObjects;

    float time;
    EnemyVariables newEnemy;

    void SpawnEnemy()
    {
        if (gameControl.is_game_over)
            return;

        newEnemy = enemyScriptableObjects[the_chance()].EnemyVariables;
        newEnemy.target = tower_target;

        int spawn_rate = (int)time / 20 + 1; // In every 20 seconds, spawning enemy number increasing by 1

        for (int i = 0; i < spawn_rate; i++)
        {
            GameObject currentEnemy = Instantiate(newEnemy.enemyPrefab, new Vector3(GetRandomPositionOutsideView().x, 0, GetRandomPositionOutsideView().z), Quaternion.identity);
            currentEnemy.GetComponent<Enemy>().variables = newEnemy;
        }
    }

    private void Update()
    {
        time += Time.deltaTime; 
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }

    int the_chance()
    {
        // 0 - 7 = default
        // 7 - 12 = fast
        // > 12 = bigslow
        int x = Random.Range(0, 15);

        if (x < 7) return 0;
        else if (x > 12) return 2;
        else return 1;
    }


    Vector3 GetRandomPositionOutsideView()
    {
        Bounds bounds = safeAreaCube.GetComponent<Renderer>().bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }

}
