
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int playerHealth = 100;
    private float speed = 5f, rotation = 20f;
    public float damage = 0.5f;
    public int meter = 1000;

    public InputActionAsset actions;

    private InputAction P_Move, P_Aim, P_Fire;
    private Vector2 P_moveAmt, P_aimAmt;
    Vector3 pos;
    [SerializeField] Transform PlayerPos;
    [SerializeField] BoxCollider PlayerCollider;
    Rigidbody Player_rb;

    public Transform Barrel;
    public Rigidbody BeamGun_rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    private void OnEnable()
    {
       actions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        Debug.Log("Proton Meter: " + meter);
        pos = PlayerPos.position;

        P_Move = InputSystem.actions.FindAction("Move");
        P_Aim = InputSystem.actions.FindAction("Aim");
        P_Fire = InputSystem.actions.FindAction("Attack");

        Player_rb = GetComponent<Rigidbody>();
        Barrel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        P_moveAmt = P_Move.ReadValue<Vector2>();
        P_aimAmt = P_Aim.ReadValue<Vector2>();

        if (P_Fire.IsPressed())
        {
            StopAllCoroutines();
            Fire();
        }
        if (P_Fire.WasReleasedThisFrame())
        {
            if (Barrel.gameObject.activeSelf)
            {
                Barrel.gameObject.SetActive(false);
                Debug.Log("Proton Meter: " + meter);
            }
            StartCoroutine(RechargeMeter());
        }
        if(meter <= 0)
            Barrel.gameObject.SetActive(false);

        if(playerHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        //Text meterdisplay = meterGUI.GetComponent<Text>();
        //meterdisplay.text = meter.ToString();
    }

    private void FixedUpdate()
    {
        Moving();
        Aiming();
    }

    private void Moving()
    {
        Player_rb.MovePosition(Player_rb.position + transform.right * P_moveAmt.x * speed * Time.deltaTime);
        BeamGun_rb.MovePosition(BeamGun_rb.position + transform.right * P_moveAmt.x * speed * Time.deltaTime);
    }

    private void Aiming()
    {
        if (BeamGun_rb.rotation.z <= 30 && BeamGun_rb.rotation.z >= -30)
        {
            float r = P_aimAmt.x * rotation * Time.deltaTime;
            Quaternion deltaRot = Quaternion.Euler(0, 0, -r);
            BeamGun_rb.MoveRotation(BeamGun_rb.rotation * deltaRot);
        }
    }

    private void Fire()
    {
        CancelInvoke();
        if (meter > 0)
        {
            Barrel.gameObject.SetActive(true);
            meter -= 5;
        }
    }
    public void TakeDamage(float f)
    {
        playerHealth -= (int)f;
    }

    private void PowerUp(String name)
    {
        switch (name)
        {
            /*case ("Peposertib"):
                GameObject[] CurrentEnemies = 
                break;*/
            case ("Temozolomide"):

                break;
        }
    }

    IEnumerator RechargeMeter()
    {
        yield return new WaitForSeconds(2f);
        while (meter <= 1000)
        {
            yield return new WaitForSeconds(0.1f);
            meter += 50;
            Debug.Log("Proton Meter: " + meter);
        }
    }
}
