using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_tail : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement_for_planer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 20);

            gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * Random.Range(10, 80), ForceMode.Force);
            gameObject.GetComponent<SpringJoint>().connectedBody = player.GetComponent<Rigidbody>();
            StartCoroutine("ReleaseTheBonus");
        }
    }

    IEnumerator ReleaseTheBonus()
    {
        yield return new WaitForSeconds(10);
        gameObject.GetComponent<SpringJoint>().connectedBody = null;
    }
}
