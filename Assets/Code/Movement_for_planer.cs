using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement_for_planer : MonoBehaviour
{
    public float forceZ, forceY, startforceZ, startforceY, accumulativeForce;
    public float mouseX, mouseY;
    public float boost, maxSpeed = 300f, maxSpeedBreaker;
    public GameObject Rotational_point;
    public Transform LeftPoint, CentrePoint, RightPoint;
    private Rigidbody rigidbody;
    public bool isWindFlow, isDelay, Invincible = false, lazerHit = false;
    public Image Boost_Image;
    public GameObject Button, DeathScreen;
    public ReviveAfterAd reviveAfterAd;
    public int adCounter;
    public GameObject Engines, Barier;
    public Material Shield, PreviousMaterial;
    private Distance_traveld_indicator distance_Traveld_Indicator;
    public Animator uiAnimator;

    [Header("DeathScreen")]

    public GameObject TabletModel_DeathScreen;
    public GameObject Button_DeathScreen;
    public GameObject Revive_Button;
    void Start()
    {
        distance_Traveld_Indicator = gameObject.GetComponent<Distance_traveld_indicator>();
        startforceZ = forceZ;
        startforceY = forceY;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    public void BeginTheJournej()
    {
        Button.gameObject.GetComponent<Animator>().enabled = false;
        StartCoroutine(CameraRotation());
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.AddForce(transform.up * 2);
        rigidbody.AddForce(transform.forward * 10);
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
    }

    private IEnumerator CameraRotation()
    {
        while (Camera.main.transform.rotation != Quaternion.Euler(8.677f, 0f, 0f))
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
        Debug.Log(rigidbody.velocity.z);
        maxSpeedBreaker = distance_Traveld_Indicator.maxSpeedBreaker;
        Boost_Image.fillAmount = boost;
        rigidbody.AddForce(transform.up * forceY);
        rigidbody.AddForce(transform.forward * forceZ);

        //if(maxSpeedBreaker >= 700)
        //{
        //    //uiAnimator.SetTrigger("Increase the speed");
        //    uiAnimator.Play("Increase the max speed");
        //    maxSpeed += 5;
        //    maxSpeedBreaker = 0;
        //}
        if (Input.GetKey(KeyCode.LeftShift) && boost > 0f && !isDelay)
        {
            forceZ += 0.5f;
            forceY += 0.5f;
            boost -= 0.013f;
        }
        else if (boost < 1f /*&& !Input.GetKey(KeyCode.LeftShift)*/ && isDelay)
        {
            forceY = startforceY;
            forceZ = startforceZ;
            boost += 0.005f;
        }

        if (Input.GetKey(KeyCode.LeftControl) && boost > 0f && !isDelay)
        {
            rigidbody.AddForce(-transform.up * 100, ForceMode.Impulse);
            boost = 0f;
        }

        if (boost <= 0)
            isDelay = true;
        else if (boost >= 1)
            isDelay = false;

        if (rigidbody.velocity.z >= maxSpeed)
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 250f);
        }
        else if (rigidbody.velocity.y >= maxSpeed)
        {
            rigidbody.velocity = new Vector3(0f, 150f, rigidbody.velocity.z);
        }

        Rotational_point.transform.rotation = Quaternion.Euler(Rotational_point.transform.rotation.x,
            Rotational_point.transform.rotation.y, -rigidbody.velocity.z / 6 + Rotational_point.transform.rotation.z);
    }
    private void Update()
    {
        MovmentByKeyboard();
        RotationByKeyboard();


    }

    public void ReviveButtonPressed()
    {
        Revive_Button.transform.SetParent(null);
    }

    public void Respawn()
    {
        if (/*gameObject.GetComponent<ReviveAfterAd>().addFinished &&*/ adCounter < 1)
        {
            adCounter++;
            StartCoroutine(ReviveBonus());
            lazerHit = false;
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            DeathScreen.SetActive(false);
            reviveAfterAd.addFinished = false;
            gameObject.GetComponent<Collider>().isTrigger = false;
            Invincible = true;
            Engines.GetComponent<MeshRenderer>().materials[0] = Shield;
            Barier.SetActive(true);

        }

        else
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
            Time.timeScale = 1;
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);

    }
    private void MovmentByKeyboard()
    {
        if (Input.GetKey(KeyCode.A) && !isWindFlow && !lazerHit)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                LeftPoint.position.x, transform.position.y, transform.position.z), 2 * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, gameObject.transform.rotation.z - 20), 2 * Time.deltaTime);
            //gameObject.transform.Rotate(new Vector3(0, -3, 0));
            //MoveLeft++;
        }
        else if (Input.GetKey(KeyCode.D) && !isWindFlow && !lazerHit)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                RightPoint.position.x, transform.position.y, transform.position.z), 2 * Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, gameObject.transform.rotation.z + 20), 2 * Time.deltaTime);
            //gameObject.transform.Rotate(new Vector3(0, -3, 0));
            //MoveLeft++;
        }
        else if(!lazerHit)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(
                 CentrePoint.position.x, transform.position.y, transform.position.z), 10 * Time.deltaTime);
            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
            //    Quaternion.Euler(0, 0, transform.rotation.z), 20 * Time.deltaTime);
        }

    }
    private void RotationByKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.S) && accumulativeForce == 1 && !isWindFlow && !lazerHit)
        {
            rigidbody.AddForce(transform.forward * 600, ForceMode.Impulse);
            rigidbody.AddForce(transform.up * 400, ForceMode.Impulse);
            accumulativeForce = 0.5f;
        }
        if (Input.GetKey(KeyCode.S) && !isWindFlow && !lazerHit)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(gameObject.transform.rotation.x - 20, 0, 0), 2 * Time.deltaTime);

            if (accumulativeForce > 0)
            {
                accumulativeForce -= 0.4f * Time.deltaTime;

                forceZ += 150f * Time.deltaTime;
                forceY += 200f * Time.deltaTime;
            }

        }
        else if (Input.GetKey(KeyCode.W) && !isWindFlow && !lazerHit)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(gameObject.transform.rotation.x + 20, 0, 0), 2 * Time.deltaTime);
            forceZ += 0.2f * Time.deltaTime;
            if (accumulativeForce < 1)
                accumulativeForce += 0.5f * Time.deltaTime;
            else
                accumulativeForce = 1f;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, transform.rotation.z), 10 * Time.deltaTime);
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
        if(lazerHit) return;

        float randomForce = Random.RandomRange(-100f, 100f);
        if (other.gameObject.CompareTag("TorbulenceZone"))
        {
            rigidbody.AddForce(transform.up * randomForce, ForceMode.Impulse);
            rigidbody.AddForce(transform.right * randomForce, ForceMode.Impulse);
            rigidbody.velocity = new Vector3(0f, 25f, rigidbody.velocity.z);
        }

        float halfY = 16.25f;
        if (other.gameObject.CompareTag("AirZone") && transform.position.y > halfY)
        {
            rigidbody.AddForce(-transform.up * 30, ForceMode.Force);
        }
        else if (other.gameObject.CompareTag("AirZone") && transform.position.y < halfY)
        {
            rigidbody.AddForce(transform.up * 30, ForceMode.Force);
        }



        
        //else if (!lazerHit)
        //{
        //    rigidbody.constraints = RigidbodyConstraints.None;
        //    rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        //    gameObject.GetComponent<Collider>().isTrigger = false;
        //}

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid") && rigidbody.velocity.z <= maxSpeed - 50 && !Invincible)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            lazerHit = true;
            GameOver();
            Debug.Log("HIT");
        }

        if (other.gameObject.CompareTag("Dash Bonus"))
            rigidbody.AddForce(transform.forward * 1000, ForceMode.Impulse);
        if (other.gameObject.CompareTag("Invincibility Bonus"))
        {
            Invincible = true;
            Engines.GetComponent<MeshRenderer>().materials[0] = Shield;
            Barier.SetActive(true);
            StartCoroutine(TimerForIVbonus());
        }

        if (other.gameObject.CompareTag("Lazer") && !Invincible)
        {
            lazerHit = true;
            GameOver();
        }

        if (other.gameObject.CompareTag("Wind") && !lazerHit)
        {
            isWindFlow = true;
            rigidbody.AddForce(transform.forward * 100, ForceMode.Force);
            rigidbody.AddForce(transform.up * 70, ForceMode.Force);
            rigidbody.AddForce(-transform.up * 45, ForceMode.Force);
            StartCoroutine(TimeBeforeInStreamMode());
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,
                Quaternion.Euler(0, 0, 0), 2 * Time.deltaTime);
        }
    }

    private void GameOver()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        TabletModel_DeathScreen.gameObject.GetComponent<Animator>().SetTrigger("Hit");
        Camera.main.GetComponent<Animator>().SetTrigger("DeadCam");
        if (adCounter >= 1)
            SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        { 
            uiAnimator.Play("Increase the max speed");
            maxSpeed += 5;
        }

    }
    private IEnumerator TimerForIVbonus()
    {
        yield return new WaitForSeconds(15f);
        Invincible = false;
        Engines.GetComponent<MeshRenderer>().materials[0] = PreviousMaterial;
        Barier.SetActive(false);
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
    private IEnumerator ReviveBonus()
    {
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Collider>().isTrigger = false;
        Engines.GetComponent<MeshRenderer>().materials[0] = PreviousMaterial;
        Barier.SetActive(false);
        Invincible = false;
    }
    private IEnumerator TimeBeforeInStreamMode()
    {
        if(!lazerHit)
        {
            yield return new WaitForSeconds(3f);
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wind") && !lazerHit)
        { 
            isWindFlow = false;
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (other.gameObject.CompareTag("Wind") && (rigidbody.velocity.z > 250 || rigidbody.velocity.y > 250))
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 100f);
            //rigidbody.velocity = new Vector3(0f, 100f, rigidbody.velocity.z);
        }
    }
    //private void RotationByMouse()
    //{
    //    mouseX = Input.GetAxis("Mouse X");
    //    mouseY = Input.GetAxis("Mouse Y");
    //    transform.Rotate(mouseY, mouseX, 0);
    //    transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    //}
}

