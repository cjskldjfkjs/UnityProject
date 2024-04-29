using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    public GameObject[] Lazer;
    public int randomaizer;
    public GameObject Lazer_HitBox;
    public GameObject RandomLazerPoint, RandomLazerUpPoint;
    [Header("lOWER")]
    [SerializeField] private GameObject CenterlazerspawnPoint, RightlazerspawnPoint, LeftlazerspawnPoint, LowerLevel;
    [Header("UPPER")]
    [SerializeField] private GameObject CenterlazerspawnPointUP, RightlazerspawnPointUP, LeftlazerspawnPointUP, UpperLevel;
    void Start()
    {
        int i = 3;
        while (i > 0)
        {
            randomaizer = Random.Range(0, 3);
            RandomLazerPoint = Instantiate(Lazer[randomaizer], new Vector3(0, 0, 0), Quaternion.identity);
            RandomLazerPoint.transform.SetParent(LowerLevel.transform);
            RandomLazerPoint.transform.position = new Vector3(Lazer[randomaizer].transform.position.x, LowerLevel.transform.position.y, LowerLevel.transform.position.z + Random.Range(-2000f, 2000f));
            Instantiate(Lazer_HitBox, new Vector3(RandomLazerPoint.transform.position.x, RandomLazerPoint.transform.position.y, RandomLazerPoint.transform.position.z), Quaternion.identity);
            RandomLazerPoint.SetActive(true);
            RandomLazerUpPoint = Instantiate(Lazer[randomaizer], new Vector3(Lazer[randomaizer].transform.position.x, UpperLevel.transform.position.y, RandomLazerPoint.transform.position.z), Quaternion.Euler(0, 0, 180f));
            RandomLazerUpPoint.transform.SetParent(UpperLevel.transform);
            RandomLazerUpPoint.SetActive(true);
            //LazerBeam.transform.position = new Vector3(RandomLazerPoint.transform.position.x, RandomLazerPoint.transform.position.y, RandomLazerPoint.transform.position.z);
            //HitBox.transform.position = new Vector3(RandomLazerPoint.transform.position.x, RandomLazerPoint.transform.position.y, RandomLazerPoint.transform.position.z);
            i--;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //LazerBeam.transform.position = new Vector3(RandomLazerPoint.transform.position.x, RandomLazerPoint.transform.position.y, RandomLazerPoint.transform.position.z);
        //LazerBeam.transform.position = new Vector3(RandomLazerUpPoint.transform.position.x, RandomLazerUpPoint.transform.position.y, RandomLazerUpPoint.transform.position.z);
    }

}
