using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject[] SpawnedEnemies = new GameObject[5];
    public Transform[] SpawnLocs = new Transform[5];
    int counter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 15; i++) {
        EnemyList.Add(Enemy);
        }
        InvokeRepeating("Spawn", 2f, 3f);
    }

    void Spawn()
    {
        if (SpawnLocs.Length != 0 && EnemyList.Count != 0)
        {
            if (EnemyList[0] != null && SpawnedEnemies[counter%5] == null)
            {
                GameObject newEnemy = Instantiate(EnemyList[0], SpawnLocs[counter % 5]);
                SpawnedEnemies[counter % 5] = newEnemy;
                EnemyList.Remove(EnemyList[0]);
            }
        }
        counter++;
    }

    /*void AddToSpawned(GameObject newEnemy)
    {
        for (int i = SpawnedEnemies.Length - 1; i >= 0; i--)
        {
            if (SpawnedEnemies[i] == null)
            {
                EnemyList[i] = newEnemy;
                return;
            }
        }
    }

    int checkSpawned()
    {
        int space = -1;
        for (int i = SpawnedEnemies.Length-1; i >= 0; i--)
        {
            if(SpawnedEnemies[i] == null)
            {
               space = i;
                break;
            }
        }
        return space;
    }*/

    // Update is called once per frame
    void Update()
    {
        if (EnemyList.Count <= 0)
        {
            CancelInvoke();
        }
    }
}
