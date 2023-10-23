using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem Trail1, Trail2, Trail3;
    [SerializeField] private TrailRenderer Trail;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigidbody.velocity.z >=200 || rigidbody.velocity.y >= 200)
        { 
            Trail1.startLifetime = 10f;
            Trail2.startLifetime = 10f;
            Trail3.startLifetime = 10f;
            Trail.time = 5f;
        }
    }
}
