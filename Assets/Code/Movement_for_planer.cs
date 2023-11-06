using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_for_planer : MonoBehaviour
{
    public float forceZ, forceY, startforceZ, startforceY, accumulativeForce;
    public float mouseX, mouseY;
    public Transform LeftPoint, CentrePoint, RightPoint;
    private Rigidbody rigidbody;
    public bool isWindFlow;
    void Start()
    {
        startforceZ = forceZ;
        startforceY = forceY;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddForce(transform.up * forceY);
        rigidbody.AddForce(transform.forward * forceZ);
        if(Input.GetKey(KeyCode.LeftShift))
        { 
            forceZ+=0.5f;
            forceY+=0.5f;
        }
        else
        { 
            forceY = startforceY;
            forceZ = startforceZ;
        }
        if(rigidbody.velocity.z>=300f)
        { 
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 250f); 
        }
        else if(rigidbody.velocity.y >= 300f)
        {
            rigidbody.velocity = new Vector3(0f, 250f, rigidbody.velocity.z);
        }
    }
    private void Update()
    {
        MovmentByKeyboard();
        RotationByKeyboard();
    }

    private void MovmentByKeyboard()
    {
        if (Input.GetKey(KeyCode.A) && !isWindFlow)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                LeftPoint.position.x, transform.position.y, transform.position.z), 30 * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, gameObject.transform.rotation.z - 20), 20 * Time.deltaTime);
            //gameObject.transform.Rotate(new Vector3(0, -3, 0));
            //MoveLeft++;
        }
        else if (Input.GetKey(KeyCode.D) && !isWindFlow)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                RightPoint.position.x, transform.position.y, transform.position.z), 30 * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, gameObject.transform.rotation.z + 20), 20 * Time.deltaTime);
            //gameObject.transform.Rotate(new Vector3(0, -3, 0));
            //MoveLeft++;
        }
        else
        { 
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                 CentrePoint.position.x, transform.position.y, transform.position.z), 30 * Time.deltaTime);
            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
            //    Quaternion.Euler(0, 0, transform.rotation.z), 20 * Time.deltaTime);
        }
    
    }
    private void RotationByKeyboard()
    {   if(Input.GetKeyDown(KeyCode.S) && accumulativeForce == 1 && !isWindFlow)
        { 
            rigidbody.AddForce(transform.forward * 600, ForceMode.Impulse);
            rigidbody.AddForce(transform.up * 400, ForceMode.Impulse);
            accumulativeForce =0.5f;
        }
        if(Input.GetKey(KeyCode.S) && !isWindFlow)
        { 
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, 
                Quaternion.Euler(gameObject.transform.rotation.x-20, 0, 0), 20 * Time.deltaTime);
            
            if (accumulativeForce > 0)
            {
                accumulativeForce -= 0.4f * Time.deltaTime;

                forceZ += 150f * Time.deltaTime;
                forceY += 200f * Time.deltaTime;
            }
                
        }
        else if (Input.GetKey(KeyCode.W) && !isWindFlow)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(gameObject.transform.rotation.x + 20, 0, 0), 20 * Time.deltaTime);
            forceZ += 0.2f*Time.deltaTime;
            if (accumulativeForce<1)
                accumulativeForce+=0.5f*Time.deltaTime;
            else
                accumulativeForce=1f;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, transform.rotation.z), 20 * Time.deltaTime);
            if (accumulativeForce > 0)
            { 
                accumulativeForce -= 0.3f * Time.deltaTime;
                forceZ += 0.03f;
            }
            else
            {
                accumulativeForce = 0;
                forceY = startforceY;
                forceZ = startforceZ;
            }
                
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Wind"))
        { 
            isWindFlow = true;
            rigidbody.AddForce(transform.forward * 100, ForceMode.Force);
            rigidbody.AddForce(transform.up * 70, ForceMode.Force);
            rigidbody.AddForce(-transform.up * 50, ForceMode.Force);
            rigidbody.useGravity = false;
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, 0), 20 * Time.deltaTime);
        }
        rigidbody.useGravity = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
            isWindFlow = false;
    }
    private void RotationByMouse()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(mouseY, mouseX, 0);
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}

