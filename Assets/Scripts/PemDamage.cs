using System.Collections;
using UnityEngine;

public class PemDamage : MonoBehaviour
{
    float damage = 0.1f;
    public GameObject Enemy;
    Collider[] enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    /*private void Poison(Collider c)
    {
        foreach (Collider c in enemies)
        {
            if(c != null)
                c.GetComponent<Enemies>().TakeDamage(damage);
        }
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy = other.gameObject;
            //StartCoroutine(Poison());
            //other.gameObject.GetComponent<Enemies>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }*/

    private void FixedUpdate()
    {
        enemies = Physics.OverlapSphere(this.transform.position, this.transform.localScale.x);
        if( enemies.Length > 0)
        {
            foreach (Collider c in enemies)
            {
                if (c != null && c.tag == "Enemy")
                    c.GetComponent<Enemies>().TakeDamage(damage);
            }
        }
    }
}
