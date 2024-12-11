using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeamMovment : MonoBehaviour
{
    public LazerSpawner LazerSpawner;
    private float lazerHeight, lazerBottom;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lazerHeight = GameObject.Find("Upper level").transform.position.y - 20f;
        lazerBottom = GameObject.Find("Lower level").transform.position.y + 20f;

        gameObject.transform.Translate(Vector3.up * 50 * direction);
        if(gameObject.transform.position.y >= lazerHeight)
            direction = -1;
        else if(gameObject.transform.position.y <= lazerBottom)
            direction = 1;
    }
    void TestMovment()
    {
        //if (gameObject.transform.position.y <= LazerSpawner.RandomLazerUpPoint.transform.position.y &&
        //    gameObject.transform.position.y > LazerSpawner.RandomLazerUpPoint.transform.position.y / 2)
        //{
        //    gameObject.transform.position += new Vector3(LazerSpawner.RandomLazerUpPoint.transform.position.x,
        //        4, LazerSpawner.RandomLazerUpPoint.transform.position.z);
        //}
        //else if (gameObject.transform.position.y >= LazerSpawner.RandomLazerPoint.transform.position.y &&
        //    gameObject.transform.position.y < LazerSpawner.RandomLazerUpPoint.transform.position.y / 2)
        //{
        //    gameObject.transform.position -= new Vector3(LazerSpawner.RandomLazerPoint.transform.position.x,
        //        4, LazerSpawner.RandomLazerPoint.transform.position.z);
        //}
    }
}
