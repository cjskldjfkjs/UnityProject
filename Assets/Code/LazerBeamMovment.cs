using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeamMovment : MonoBehaviour
{
    private LazerSpawner LazerSpawner;
    private GameObject LowerPoint, UpperPoint;
    // Start is called before the first frame update
    void Start()
    {
        LowerPoint.transform.position = LazerSpawner.RandomLazerPoint.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
