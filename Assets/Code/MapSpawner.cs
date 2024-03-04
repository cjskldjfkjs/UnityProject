using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject wind_plane, normal_plane,plane0;
    public int count = 1;
    public int randomaizer;
    public GameObject[] planes;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plane"))
        {
            randomaizer = Random.Range(0, 4);
            Instantiate(planes[randomaizer], plane0.transform.position + new Vector3(0, 0, 3259f*count), Quaternion.identity);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
