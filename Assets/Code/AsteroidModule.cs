using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModule : MonoBehaviour
{
    public GameObject player;
    public GameObject asteroidBoomEfect;

    public GameObject[] Bonuses;
    private GameObject dashBonus, shieldBonus, coin;

    private string playerTag;

    private int randomBonus;

    void Start()
    {
        player = GameObject.Find("PlaneModel");
        playerTag = player.gameObject.tag;     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        randomBonus = Random.Range(0, 2);
        if(other.gameObject.tag == playerTag && !player.GetComponent<Movement_for_planer>().lazerHit && 
            !player.GetComponent<Movement_for_planer>().Invincible && 
            player.GetComponent<Rigidbody>().velocity.z <= player.GetComponent<Movement_for_planer>().maxSpeed)
        { 
            Instantiate(asteroidBoomEfect, gameObject.transform.position, Quaternion.identity);
            Instantiate(Bonuses[randomBonus], gameObject.transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
    }
}
