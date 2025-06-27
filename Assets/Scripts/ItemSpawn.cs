using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> powers = new List<GameObject>(); 
    public Transform[] transforms = new Transform[3];
    static int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnPower", 5f, 5f);
    }

    void SpawnPower()
    {
        Rigidbody item = Instantiate(powers[counter%3].GetComponent<Rigidbody>(), transforms[counter%3].position + transforms[counter%3].forward, Quaternion.identity).GetComponent<Rigidbody>();
        item.AddForce(transforms[counter % 3].forward*3, ForceMode.Impulse);
        counter++;
        Destroy(item.gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
