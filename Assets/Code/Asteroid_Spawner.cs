using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject player;

    private GameObject theAsteroid;
    void Start()
    {
        InvokeRepeating(nameof(Spawner), 10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawner()
    { 
        theAsteroid = Instantiate(asteroid, new Vector3(0,0,0), Quaternion.identity);
        theAsteroid.transform.position = new Vector3(0, player.transform.position.y + 5, player.transform.position.z + 1200);
        theAsteroid.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 1000, ForceMode.Impulse);
        theAsteroid.GetComponent<Rigidbody>().AddTorque(Vector3.right * 50, ForceMode.Impulse);
        //theAsteroid.GetComponent<Rigidbody>().AddForceAtPosition(-Vector3.forward * 15, new Vector3(theAsteroid.transform.position.x - 5, 
        //    theAsteroid.transform.position.y, theAsteroid.transform.position.z), ForceMode.Force);
    }
}
