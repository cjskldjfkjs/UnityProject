using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonus : MonoBehaviour
{
    public GameObject DashBonusEffect, ShieldBonusEffect;
    public GameObject Player, DashBonus, ShieldBonus;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dash Bonus"))
        {
            Instantiate(DashBonusEffect, Player.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Invincibility Bonus"))
        {
            Instantiate(ShieldBonusEffect, Player.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
