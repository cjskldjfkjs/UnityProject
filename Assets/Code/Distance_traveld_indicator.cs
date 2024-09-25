using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_traveld_indicator : MonoBehaviour
{
    public GameObject startPoint;

    private float distance, i;

    private bool switchIndicators;

    public Image distanceIndicator, distanceIndicator1;
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
        if (!switchIndicators && i % 2 == 0)
        {
            distance = Mathf.RoundToInt(Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5));
            distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, distance);
        }

        if (distance >= 250)
        {
            switchIndicators = true;
            distance = 0;
            i++;
        }

        if (switchIndicators && i % 2 != 0)
        {
            startPoint.transform.position = new Vector3(0, 0, startPoint.transform.position.z + 103 * i);
            distance = Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z) / 5);
            distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, distance);
        }
    }
}
