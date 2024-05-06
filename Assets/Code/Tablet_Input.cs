using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Input : MonoBehaviour
{
    private RaycastHit hit;
    public Camera mainCamera;
    public GameObject HitPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            { 
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
                hit.collider.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(1,10),
                    Random.Range(10, 50), Random.Range(10, 20)), ForceMode.Impulse);
            }
        }  
    }
}
