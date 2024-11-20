using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance_traveld_indicator : MonoBehaviour
{
    public GameObject startPoint;

    private float distance1, distance2, i, DCanvas1, DCanvas2;

    public float maxSpeedBreaker;

    private float distanceTraveled;

    private bool switchIndicators;

    public Image distanceIndicator, distanceIndicator1;

    public TMP_Text distanceTraveledTMPro, distanceTraveledTMProEffect;

    public GameObject distanceTraveledText;

    [SerializeField]
    private GameObject DistanceCanvas1, DistanceCanvas2;

    [SerializeField]
    private GameObject distanceEffect;

    public Animator break250Anim;

    [SerializeField]
    private float randomR, randomG, randomB;
    // Start is called before the first frame update
    void Start()
    {
        break250Anim = distanceEffect.GetComponent<Animator>();
        distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        switchIndicators = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceTraveledTMProEffect.text = distanceTraveled.ToString();
        distanceTraveledTMPro.text = distanceTraveled.ToString();

        if (maxSpeedBreaker >= 700)
        { 
            maxSpeedBreaker = 0;
        }

        if (distance1 < 250 && !switchIndicators)
        {
            distance1 = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance1, distance1);
        }

        else if (distance1 >= 250 && !switchIndicators)
        {
            distanceTraveled += distance1;
            maxSpeedBreaker += distance1;
            break250Anim.SetTrigger("Broke 250");
            distance2 = 0;
            RandomColor();
            switchIndicators = true;
            distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(distance2, distance2);
            DistanceCanvas1.GetComponent<Canvas>().sortingOrder = 0;
            DistanceCanvas2.GetComponent<Canvas>().sortingOrder = 1;
            distanceIndicator1.color = new Color(randomR, randomG, randomB);
            startPoint.transform.position = new Vector3(0, 0, startPoint.transform.position.z + 1100);
        }

        if (distance2 < 250 && switchIndicators)
        {
            distance2 = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(distance2, distance2);
        }

        else if (distance2 >= 250 && switchIndicators)
        {
            distanceTraveled += distance2;
            maxSpeedBreaker += distance2;
            break250Anim.SetTrigger("Broke 250");
            distance1 = 0;
            RandomColor();
            switchIndicators = false;
            distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance1, distance1);
            DistanceCanvas2.GetComponent<Canvas>().sortingOrder = 0;
            DistanceCanvas1.GetComponent<Canvas>().sortingOrder = 1;
            distanceIndicator.color = new Color(randomR, randomG, randomB);
            startPoint.transform.position = new Vector3(0, 0, Mathf.Abs(startPoint.transform.position.z + 1100));
        }
    }
    private void RandomColor()
    {
        randomR = Random.RandomRange(0f, 1f);
        randomG = Random.RandomRange(0f, 1f);
        randomB = Random.RandomRange(0f, 1f);
    }
}
