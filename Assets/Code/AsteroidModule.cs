using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModule : MonoBehaviour
{
    public GameObject player;

    public GameObject[] Bonuses;
    private GameObject dashBonus, shieldBonus;

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

    private void OnCollisionEnter(Collision collision)
    {
        randomBonus = Random.Range(0, 1);
        if(collision.gameObject.tag == playerTag)
        { 
            Instantiate(Bonuses[randomBonus], gameObject.transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
    }
}
