using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement_for_planer player_code;
    public GameObject thePlayer;
    private Vector3 localStartPosition;
    private Quaternion localStartRotation;

    void Start()
    {
        localStartPosition = gameObject.transform.localPosition;
        localStartRotation = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        player_code.TabletModel_DeathScreen.gameObject.GetComponent<Animator>().SetTrigger("Revive");
        thePlayer.GetComponent<ReviveAfterAd>().AdForRevive();
        //player.Respawn();
        
    }

    public void ResetPosition()
    { 
        gameObject.transform.localPosition = localStartPosition;
        gameObject.transform.localRotation = localStartRotation;
    }
}
