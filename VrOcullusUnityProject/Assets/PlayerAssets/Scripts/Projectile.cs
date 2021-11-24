using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float destroySelfTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", destroySelfTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroySelf();
    }
    private void OnTriggerEnter(Collider other)
    {
        DestroySelf();
    }

}
