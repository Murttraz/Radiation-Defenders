using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> powers = new List<GameObject>(); 
    public Transform[] transforms = new Transform[3];
    static int counter = 0, pCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnPower", 5f, 5f);
        pCount = powers.Count;

    }

    void SpawnPower()
    {
        counter = Random.Range(0, transforms.Length - 1);
        Rigidbody item = Instantiate(powers[counter% pCount].GetComponent<Rigidbody>(), transforms[counter% pCount].position + transforms[counter%pCount].forward, Quaternion.identity).GetComponent<Rigidbody>();
        item.AddForce(transforms[counter % pCount].forward*3, ForceMode.Impulse);
        //counter++;
        Destroy(item.gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
