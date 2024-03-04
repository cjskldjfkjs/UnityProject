using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Spawner : MonoBehaviour
{
    public GameObject[] Bonus;
    public int[] Xcoordinate;
    public GameObject spawnPoint, bonusPosition, canvas;
    private int randomaizer;
    private int randomaizerX;
    void Start()
    {
        randomaizer = Random.Range(0, 2);
        bonusPosition = Instantiate(Bonus[randomaizer], spawnPoint.transform.position + new Vector3(Xcoordinate[randomaizerX], 
            Random.Range(0, 1000), Random.Range(0, 1000)), Quaternion.identity);
        bonusPosition.transform.SetParent(canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
