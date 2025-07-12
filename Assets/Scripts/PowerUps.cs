using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    string PowerType;
    Player player;
    EnemySpawn CurrentEnemies;
    GameObject Beam;
    public GameObject[] PemPoisons;

    //List<GameObject> EnemyList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (this.gameObject.name.Contains("Peposertib"))
            PowerType = "Peposertib";
        else if (this.gameObject.name.Contains("Temozolomide"))
            PowerType = "Temozolomide";
        else if (this.gameObject.name.Contains("Pembrolizumab")) {
            PowerType = "Pembrolizumab";
            PemPoisons = GameObject.FindGameObjectsWithTag("Pem");
        }

        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        CurrentEnemies = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        Beam = GameObject.Find("Barrel");
    }

    IEnumerator Temo()
    {
        player.damage = 1f;
        yield return new WaitForSeconds(5f);
        player.damage = 0.5f;
    }

    IEnumerator Pem()
    {
        foreach (GameObject p in PemPoisons)
        {
            if (p != null && p.transform.position.y <= 0)
            {
                p.transform.Translate(0, 5, 0);
            }
        }
        yield return new WaitForSecondsRealtime(5f);
        foreach (GameObject p in PemPoisons)
        {
            if (p != null)
            {
                p.transform.Translate(0, -5, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            switch (PowerType)
            {
                case ("Peposertib"):
                    this.gameObject.transform.Translate(0, -5, 0);
                    foreach (GameObject c in CurrentEnemies.SpawnedEnemies)
                    {
                        if (c != null)
                            c.SendMessage("CancelInvoke");
                        
                    }
                    Destroy(this.gameObject, 1f);
                break;
                case ("Temozolomide"):
                    this.gameObject.transform.Translate(0, -5, 0);
                    StartCoroutine(Temo());
                    Destroy(this.gameObject, 6f);
                    break;
                case ("Pembrolizumab"):
                    this.gameObject.transform.Translate(0, -5, 0);
                    StartCoroutine(Pem());
                    Destroy(this.gameObject, 6f);
                    break;
            }
            //Destroy(this.gameObject, 2f);
        }
    }
}
