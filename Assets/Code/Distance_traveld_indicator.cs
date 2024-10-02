using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_traveld_indicator : MonoBehaviour
{
    public GameObject startPoint;

    private float distance1, distance2, i, DCanvas1, DCanvas2;

    private bool switchIndicators;

    public Image distanceIndicator, distanceIndicator1;

    [SerializeField]
    private GameObject DistanceCanvas1, DistanceCanvas2;
    // Start is called before the first frame update
    void Start()
    {
        distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        switchIndicators = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance1<250 && !switchIndicators)
        {   
            distance1 = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance1, distance1);
        }

        else if (distance1 >= 250 && !switchIndicators)
        {
            switchIndicators = true;
            startPoint.transform.position = new Vector3(0, 0, startPoint.transform.position.z + 1000);
            distance2 = 0;
            DistanceCanvas1.GetComponent<Canvas>().sortingOrder = 0;
            DistanceCanvas2.GetComponent<Canvas>().sortingOrder = 1;
        }

        if (distance2 < 250 && switchIndicators)
        {           
            distance2 = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(distance2, distance2);
        }

        else if (distance2 >= 250 && switchIndicators)
        {
            switchIndicators = false;
            startPoint.transform.position = new Vector3(0, 0, Mathf.Abs(startPoint.transform.position.z + 1000));
            distance1 = 0;
            DistanceCanvas1.GetComponent<Canvas>().sortingOrder = 1;
            DistanceCanvas2.GetComponent<Canvas>().sortingOrder = 0;
        }
    }
}
