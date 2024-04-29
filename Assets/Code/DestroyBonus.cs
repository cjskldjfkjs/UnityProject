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
            GameObject dash_Variable = Instantiate(DashBonusEffect, Player.transform.position, Quaternion.identity);
            dash_Variable.transform.SetParent(Player.transform);
            dash_Variable.transform.localPosition = new Vector3(0, 0, 20);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Invincibility Bonus"))
        {
            GameObject invincible_Variable = Instantiate(ShieldBonusEffect, Player.transform.position, Quaternion.identity);
            invincible_Variable.transform.SetParent(Player.transform);
            invincible_Variable.transform.localPosition = new Vector3(0, 0, 20);
            Destroy(other.gameObject);
        }
    }
}
