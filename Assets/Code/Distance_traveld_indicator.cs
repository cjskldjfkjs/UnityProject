using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance_traveld_indicator : MonoBehaviour
{
    public GameObject startPoint;

    private float distance1, distance2, distanceTraveled, i, DCanvas1, DCanvas2;

    private bool switchIndicators;

    public Image distanceIndicator, distanceIndicator1;

    private TextMeshPro distanceTraveledTMPro;

    public GameObject distanceTraveledText;

    [SerializeField]
    private GameObject DistanceCanvas1, DistanceCanvas2;

    [SerializeField]
    private float randomR, randomG, randomB;
    // Start is called before the first frame update
    void Start()
    {
        distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        switchIndicators = false;
        distanceTraveledTMPro = distanceTraveledText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceTraveledText = distanceTraveled;
        if (distance1 < 250 && !switchIndicators)
        {
            distance1 = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance1, distance1);
        }

        else if (distance1 >= 250 && !switchIndicators)
        {
            distanceTraveled = +distance1;
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
            distanceTraveled = +distance2;
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
