
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerStamina = 100;
    private float speed = 5f, rotation = 30f, intensity = 5f;
    public float damage = 0.5f, rb;
    public int meter = 1000, score;

    public InputActionAsset actions;

    private InputAction P_Move, P_Aim, P_Fire;
    public Vector2 P_moveAmt, P_aimAmt;
    Vector3 pos;
    [SerializeField] Transform PlayerPos;
    [SerializeField] BoxCollider PlayerCollider;
    Rigidbody Player_rb;

    public Transform Barrel;
    public Rigidbody BeamGun_rb, BeamEnd;

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

        score = 0;
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

        if(playerStamina <= 0)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 0f;
            SceneManager.LoadScene("DefeatScreen");
        }
        
        BeamEnd.position = Barrel.position + Barrel.forward * intensity;

        rb = BeamGun_rb.rotation.z;
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
        if ((BeamGun_rb.rotation.z <= 0.40 && P_aimAmt.x == -1) || (BeamGun_rb.rotation.z >= -0.40 && P_aimAmt.x == 1))
        {
            float r = P_aimAmt.x * rotation * Time.deltaTime;
            Quaternion deltaRot = Quaternion.Euler(0, 0, -r);
            BeamGun_rb.MoveRotation(BeamGun_rb.rotation * deltaRot);
        }

        if (intensity >= 2 && intensity <= 8)
        {
            intensity += P_aimAmt.y * Time.deltaTime * speed;
        }
        else if (intensity < 2)
        {
            intensity = 2;
        }
        else if (intensity > 8)
        {
            intensity = 8;
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
        playerStamina -= (int)f;
    }

    public void AddScore(int s)
    {
        score += s;
        Debug.Log("Score: " + score);
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
