using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject plane_1;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plane with wind"))
        { 
            Instantiate(plane_1, plane_1.transform.position + new Vector3(0, 0, plane_1.transform.localScale.z/2), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
