using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour
{
    public Player Player;
    public Enemies Enemies;
    [SerializeField] Canvas Canvas;
    public Text meterGUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meterGUI.text = "Proton Meter: " + Player.meter;
    }
}
