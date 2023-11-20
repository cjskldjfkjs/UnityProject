using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem Trail1, Trail2, Trail3;
    [SerializeField] private TrailRenderer Trail_Line1, Trail_Line2, Trail_Line3;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigidbody.velocity.z >=250 || rigidbody.velocity.y >= 250)
        { 
            Trail_Line1.time = 3f;
            Trail_Line2.time = 3f;
            Trail_Line3.time = 3f;
        }
        else
        {
            Trail_Line1.time = 0f;
            Trail_Line2.time = 0f;
            Trail_Line3.time = 0f;
        }
        if ((rigidbody.velocity.z >= 100 && rigidbody.velocity.z < 250) || (rigidbody.velocity.y >= 100 && rigidbody.velocity.y < 250))
        {
            Trail1.maxParticles = 4000;
            Trail2.maxParticles = 4000;
            Trail3.maxParticles = 4000;
        }
        else
        {
            Trail1.maxParticles = 0;
            Trail2.maxParticles = 0;
            Trail3.maxParticles = 0;
        }
    }
}
