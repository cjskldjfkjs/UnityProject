using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathscreenInput_Revive : MonoBehaviour
{
    public GameObject Deathscreen;
    public GameObject Revive_Button, Reset_Button;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathScreenReviled()
    {
        Revive_Button.transform.SetParent(null);
        Reset_Button.transform.SetParent(null);
    }

    public void DeathScreenHide()
    {
        Revive_Button.transform.SetParent(Deathscreen.transform);
        Revive_Button.GetComponent<ReviveButtonPressed>().ResetPosition();

        Reset_Button.transform.SetParent(Deathscreen.transform);
        Reset_Button.GetComponent<ReviveButtonPressed>().ResetPosition();
    }

}
