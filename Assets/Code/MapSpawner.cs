using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject torbulenceZone;

    public int count = 1;
    public int randomaizer;

    public List<GameObject> platformList;
    
    public GameObject[] planes;
    public GameObject wind_plane, normal_plane,plane0;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plane"))
        {
            randomaizer = Random.Range(0, 3);
            GameObject Plane =Instantiate(planes[randomaizer], plane0.transform.position + new Vector3(0, 0, 3259f*count), Quaternion.identity);
            Instantiate(torbulenceZone, plane0.transform.position + new Vector3(0, Random.RandomRange(147, 180), 3259f * count), Quaternion.identity);
            count++;
            platformList.Add(Plane);
        }
        
        if(platformList.Count >= 4)
        {
            Destroy(platformList[0]);
            platformList.RemoveAt(0);
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
