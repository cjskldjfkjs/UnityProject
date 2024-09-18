using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance_traveld_indicator : MonoBehaviour
{
    public GameObject startPoint;

    private float distance;

    public Image distanceIndicator, distanceIndicator1;
    // Start is called before the first frame update
    void Start()
    {
        distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        distanceIndicator1.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs((gameObject.transform.position.z - startPoint.transform.position.z)/5); 
        distanceIndicator.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, distance);
    }
}
