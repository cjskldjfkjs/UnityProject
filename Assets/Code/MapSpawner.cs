using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject plane_1, plane0;
    public int count = 1;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plane with wind"))
        {
            Instantiate(plane_1, plane0.transform.position + new Vector3(0, 0, 3259f*count), Quaternion.identity);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
