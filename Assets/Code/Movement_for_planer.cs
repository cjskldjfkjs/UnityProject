using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_for_planer : MonoBehaviour
{
    public float forceZ, forceY, startforceZ, startforceY, accumulativeForce;
    public float mouseX, mouseY;
    public float boost;
    public GameObject Rotational_point;
    public Transform LeftPoint, CentrePoint, RightPoint;
    private Rigidbody rigidbody;
    public bool isWindFlow, isDelay, Invincible = false;
    public Image Boost_Image;
    public GameObject Menu, DeathScreen;
    void Start()
    {
        startforceZ = forceZ;
        startforceY = forceY;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void BeginTheJournej()
    { 
        Menu.gameObject.SetActive(false);
        StartCoroutine(CameraRotation());
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.AddForce(transform.up * 2);
        rigidbody.AddForce(transform.forward * 10);
    }

    private IEnumerator CameraRotation()
    { 
        while(Camera.main.transform.rotation != Quaternion.Euler(8.677f, 0f, 0f))
        {
            yield return new WaitForSeconds(0.00001f);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, 
                Quaternion.Euler(8.677f, 0f, 0f), 0.99f * Time.deltaTime);
        }
        yield break;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Boost_Image.fillAmount = boost;
        rigidbody.AddForce(transform.up * forceY);
        rigidbody.AddForce(transform.forward * forceZ);
        if(Input.GetKey(KeyCode.LeftShift) && boost>0f && !isDelay)
        { 
            forceZ+=0.5f;
            forceY+=0.5f;
            boost-=0.013f;
        }
        else if(boost<1f /*&& !Input.GetKey(KeyCode.LeftShift)*/ && isDelay)
        { 
            forceY = startforceY;
            forceZ = startforceZ;
            boost+=0.005f;
        }
        if(boost <= 0)
            isDelay = true;
        else if (boost >= 1)
            isDelay = false;
        if (rigidbody.velocity.z>=300f)
        { 
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 250f); 
        }
        else if(rigidbody.velocity.y >= 300f)
        {
            rigidbody.velocity = new Vector3(0f, 250f, rigidbody.velocity.z);
        }

        Rotational_point.transform.rotation = Quaternion.Euler(Rotational_point.transform.rotation.x, 
            Rotational_point.transform.rotation.y, rigidbody.velocity.z/-5 + Rotational_point.transform.rotation.x);
    }
    private void Update()
    {
        MovmentByKeyboard();
        RotationByKeyboard();
    }

    private void Respawn()
    { 
        if(gameObject.GetComponent<ReviveAfterAd>().addFinished)
        {
            StartCoroutine(TimerForIVbonus());
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            DeathScreen.SetActive(false);
        }
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
        if(other.gameObject.CompareTag("Lazer") && !Invincible)
        { 
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            DeathScreen.SetActive(true);          
        }
            
        if (other.gameObject.CompareTag("Wind"))
        { 
            isWindFlow = true;
            rigidbody.AddForce(transform.forward * 100, ForceMode.Force);
            rigidbody.AddForce(transform.up * 70, ForceMode.Force);
            rigidbody.AddForce(-transform.up * 45, ForceMode.Force);
            StartCoroutine(TimeBeforeInStreamMode());
            rigidbody.useGravity = false;
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, 0), 20 * Time.deltaTime);
        }
        else
        { 
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        rigidbody.useGravity = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dash Bonus"))
            rigidbody.AddForce(transform.forward * 10000, ForceMode.Impulse);
        if (other.gameObject.CompareTag("Invincibility Bonus"))
        {   
            Invincible = true;
            StartCoroutine(TimerForIVbonus());
        }
    }
    private IEnumerator TimerForIVbonus ()
    { 
        yield return new WaitForSeconds(15f);
        Invincible = false;
    }
    private IEnumerator TimeBeforeInStreamMode()
    { 
        yield return new WaitForSeconds(3f);
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
            isWindFlow = false;
        if (other.gameObject.CompareTag("Wind") && (rigidbody.velocity.z > 250 || rigidbody.velocity.y > 250))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 100f);
            //rigidbody.velocity = new Vector3(0f, 100f, rigidbody.velocity.z);
        }
    }
    private void RotationByMouse()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(mouseY, mouseX, 0);
        transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}

