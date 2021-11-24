using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    private AudioManager s_AudioManager;

    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;

    private void Start()
    {
        s_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void FractureObject()
    {
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile_0"))
        {
            s_AudioManager.Play("brick_destroyed");
            FractureObject();
        }
    }

}
