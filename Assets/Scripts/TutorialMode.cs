using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class TutorialMode : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public List<Button> buttonList = new List<Button>();
    public GameObject tutorialEnemy, Enemy;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    { 
        enemySpawn.enabled = false; // Disable enemy spawning in tutorial mode
        tutorialEnemy = GameObject.FindWithTag("Enemy");
        tutorialEnemy.SetActive(false);
        buttonList[0].gameObject.SetActive(true);
        player.playerStamina = 9999;
    }

    void NextButton()
    {
        if (buttonList.Count > 1)
        {
            buttonList[0].gameObject.SetActive(false);
            buttonList.RemoveAt(0);
            buttonList[0].gameObject.SetActive(true);
            if (buttonList[0].name == "Tutor_5")
            {
                if (tutorialEnemy != null)
                {
                    tutorialEnemy.SetActive(true);
                }
            }
            if (buttonList[0].name == "Tutor_6")
            {
                enemySpawn.enabled = true; // Enable enemy spawning after tutorial
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextButton();
        }
        if(player.playerStamina <= 25)
        {
            player.playerStamina = 9999; // Prevent stamina from going below 25
        }
        if (enemySpawn.EnemyList.Count <= 0)
        {
            for (int i = 0; i < 15; i++)
            {
                enemySpawn.EnemyList.Add(Enemy);
            }
        }
    }
}
