using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTarget : MonoBehaviour
{
    [SerializeField] private AudioManager s_AudioManager;

    [SerializeField] private GameObject particle;

    [SerializeField] private GameObject menuTarget;


    // Start is called before the first frame update
    void Start()
    {
        s_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile_0"))
        {
            s_AudioManager.Play("powerup");
            Debug.Log("MenuTarget");
            Instantiate(particle, transform.position, transform.rotation);
            menuTarget.SetActive(false);
            Invoke("RespawnTarget", 2.5f);
        }

    }

    public void RespawnTarget()
    {
        menuTarget.SetActive(true);
    }

}
