using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public List<GameObject> EnemyList = new List<GameObject>();
    Scene Scene;
    public GameObject LevelClear;
    public GameObject[] SpawnedEnemies;
    public Transform[] SpawnLocs;
    int counter = 0;
    int SE, SL;
    public bool isTutorialMode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 15; i++) {
        EnemyList.Add(Enemy);
        }
        InvokeRepeating("Spawn", 2f, 3f);
        SE = SpawnedEnemies.Length-1;
        SL = SpawnLocs.Length-1;
        Scene = SceneManager.GetActiveScene();
        LevelClear.SetActive(false);
    }

    void Spawn()
    {
        int locate = Random.Range(0, SE);
        if (SpawnLocs.Length != 0 && EnemyList.Count != 0)
        {
            if (EnemyList[0] != null && SpawnedEnemies[locate % SE] == null)
            {
                GameObject newEnemy = Instantiate(EnemyList[0], SpawnLocs[locate % SL]);
                SpawnedEnemies[counter % SE] = newEnemy;
                EnemyList.Remove(EnemyList[0]);
            }
        }
        //counter++;
    }

    void enemiesDestroyed() {

        if (SceneManager.GetActiveScene().name == "Level_3") {
            SceneManager.LoadScene("FinalVictoryScreen");
        } else {
            SceneManager.LoadScene("VictoryScreen");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyList.Count <= 0)
        {
            CancelInvoke();
            if (SpawnedEnemies.Length > 0)
            {
                bool allEnemiesCleared = true;
                foreach (GameObject enemy in SpawnedEnemies)
                {
                    if (enemy != null)
                    {
                        allEnemiesCleared = false;
                        break;
                    }
                }
                if (allEnemiesCleared && !isTutorialMode)
                    LevelClear.SetActive(true);
            }
        }
        
        if (enemiesKilled == 15 && !sceneSwapped) {
            sceneSwapped = true;
            enemiesDestroyed();
        }
    }
}
