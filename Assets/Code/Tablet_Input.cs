using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet_Input : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject HitPoint, Tablet;
    public Animator animator;
    public GameObject Player;

    private Movement_for_planer movement_For_Planer;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        movement_For_Planer = Player.GetComponent<Movement_for_planer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit)/* && hit.collider.gameObject.CompareTag("startButton")*/)
        //    { 
        //        hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        //        hit.collider.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(1,10),
        //            Random.Range(10, 50), Random.Range(10, 20)), ForceMode.Impulse);
        //    }
        //}  
    }
    private void OnMouseDown()
    {
        gameObject.transform.SetParent(Tablet.transform);
        animator.SetBool("IsButtonPressed", true);
        Tablet.GetComponent<Rigidbody>().AddForce(-transform.forward * 20, ForceMode.Impulse);
        Tablet.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(1, 10),
        Random.Range(10, 50), Random.Range(10, 20)), ForceMode.Impulse);
        movement_For_Planer.BeginTheJournej();
        StartCoroutine(Selfdestraction());
    }
    private IEnumerator Selfdestraction()
    {
        yield return new WaitForSeconds(10f);
        Destroy(Tablet);
    }
}
