using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturePiece : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedmin = 0.5f;
    [SerializeField] private float speedmax = 10f;

    [SerializeField] private float destroyTimer;
    [SerializeField] private float destroyTimermin = 1f;
    [SerializeField] private float destroyTimermax = 4f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedmin, speedmax);
        GetComponent<Rigidbody>().velocity = Random.onUnitSphere * speed;
        
        destroyTimer = Random.Range(destroyTimermin, destroyTimermax);
        Invoke("DestroySelf", destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
