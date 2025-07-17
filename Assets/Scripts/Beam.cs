using UnityEngine;

public class Beam : MonoBehaviour
{
    //Credit to Dogma427 @ YouTube
    //https://youtu.be/TokDH2OSiBE?si=0lGIbyeafzvABGtB (Video I used as reference to help make this script)
    Player player;
    float Damage;
    private LineRenderer ProtonBeam;
    public Transform barrel, EndPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        ProtonBeam = GetComponent<LineRenderer>();
        Damage = player.damage;
    }

    /*private void Intensify(float intensity)
    {
        If
    }*/

    // Update is called once per frame
    void Update()
    {
        ProtonBeam.SetPosition(0, barrel.position);
        RaycastHit hit;

        if (Physics.Raycast(barrel.position, barrel.forward, out hit)) {
            if (hit.collider != null)
            {
                ProtonBeam.SetPosition(1, hit.point);
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemies>().TakeDamage(Damage);
                }
            }
            
        }
        else
        {
            ProtonBeam.SetPosition(1, EndPoint.position);
        }

        Damage = player.damage;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemies>().TakeDamage(Damage);
        }
        Destroy(this.gameObject, 5f);
    }*/

    //on
}
