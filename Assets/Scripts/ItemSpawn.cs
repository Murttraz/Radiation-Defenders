using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> powers = new List<GameObject>(); 
    public Transform[] transforms = new Transform[3];
    static int counter = 0, pCount, tCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnPower", 5f, 5f);
        pCount = powers.Count;
        tCount = transforms.Length-1;
        //counter = 0;
    }

    void SpawnPower()
    {
        Rigidbody item = Instantiate(powers[counter% pCount].GetComponent<Rigidbody>(), transforms[counter% tCount].position + transforms[counter%tCount].forward, Quaternion.identity).GetComponent<Rigidbody>();
        item.AddForce(transforms[counter % tCount].forward*3, ForceMode.Impulse);
        counter++;
        Destroy(item.gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
