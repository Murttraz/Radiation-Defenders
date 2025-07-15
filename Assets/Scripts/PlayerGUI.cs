using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    public Player Player;
    public EnemySpawn Enemies;
    public Canvas Canvas;
    Text meterGUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemies = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        meterGUI = Canvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        meterGUI.text = "Proton Meter: "+ Player.meter+"\nScore: "+ Player.score+"\t\t\tStamina: "+Player.playerHealth;
    }
}
