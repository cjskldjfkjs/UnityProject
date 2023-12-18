using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem Trail1, Trail2, Trail3, Trail4;
    [SerializeField] private TrailRenderer Trail_Line1, Trail_Line2, Trail_Line3, Trail_Line4;
    [SerializeField] private ParticleSystem Light_Speed, SonicBoom;
    [SerializeField] private Light SonicFlash;
    private Rigidbody rigidbody;
    public Animator animator;
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
            Trail_Line4.time = 3f;
            Light_Speed.maxParticles = 200;
            SonicBoom.maxParticles = 100;
            SonicFlash.intensity = 1.2f;
            animator.SetBool("IsCameraBoosted", true);
        }
        else
        {
            Trail_Line1.time = 0f;
            Trail_Line2.time = 0f;
            Trail_Line3.time = 0f;
            Trail_Line4.time = 0f;
            Light_Speed.maxParticles = 0;
            SonicBoom.maxParticles = 0;
            SonicFlash.intensity = 0f;
            animator.SetBool("IsCameraBoosted", false);
        }
        if ((rigidbody.velocity.z >= 100 && rigidbody.velocity.z < 250) || (rigidbody.velocity.y >= 100 && rigidbody.velocity.y < 250))
        {
            Trail1.maxParticles = 4000;
            Trail2.maxParticles = 4000;
            Trail3.maxParticles = 4000;
            Trail4.maxParticles = 4000;
        }
        else
        {
            Trail1.maxParticles = 0;
            Trail2.maxParticles = 0;
            Trail3.maxParticles = 0;
            Trail4.maxParticles = 0;
        }
    }
}
