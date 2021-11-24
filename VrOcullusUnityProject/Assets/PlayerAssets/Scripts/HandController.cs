using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameManager s_gameManager;
    [SerializeField] private bool inMainMenu;

    [SerializeField] private GameObject objspawn;
    [SerializeField] private GameObject objgrab;
    [SerializeField] private GameObject playerHand;

    [SerializeField] private GameObject projectile;

    [SerializeField] private Transform ProjectileSpawn;
    [SerializeField] private GameObject Projectile_0;
    [SerializeField] private float Velocity_Projectile_0 = 25f;

    [SerializeField] private bool gripDown = false;
    [SerializeField] private bool triggerDown = false;

    [SerializeField] private bool shootOnCooldown = false;
    [SerializeField] private float shootCooldownTime = 0.5f;

    [SerializeField] private bool hasDrone = false;

    private float fadeSpeed = 100000f; 

    
    void Start()
    {
        s_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inMainMenu = s_gameManager.getinMainMenuBool();
    }

    void Update()
    {
        if (triggerDown && !shootOnCooldown && hasDrone)
        {
            ShootProjectile_0();
        }
        
        if (!gripDown && hasDrone && inMainMenu)
        {
            Debug.Log("PUTITAWAYPUTITAWAYPUTITAWAYPUTITAWAY");
            objspawn.SetActive(false);
            playerHand.SetActive(true);
            objgrab.SetActive(true);
            hasDrone = false;
        }
        
    }
    private void FixedUpdate()
    {
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("grabbable") && gripDown == true)
        {
            Debug.Log("trigger");
            objgrab = other.gameObject;
            objspawn.SetActive(true);
            playerHand.SetActive(false);

            other.gameObject.SetActive(false);
            hasDrone = true;
        }
    }

    public void ShootProjectile_0()
    {
        projectile = Instantiate(Projectile_0, ProjectileSpawn.position, ProjectileSpawn.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(ProjectileSpawn.forward * Velocity_Projectile_0, ForceMode.Impulse);
        shootOnCooldown = true;
        Invoke("ShootingCooldownDone", shootCooldownTime);
    }

    public void ShootingCooldownDone()
    {
        shootOnCooldown = false;
    }

    public void setGrip(bool value)
    {
        gripDown = value;
    }

    public void setTrigger(bool value)
    {
        triggerDown = value;
    }

}
