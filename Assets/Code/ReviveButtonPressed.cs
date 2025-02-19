using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement_for_planer player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        player.Respawn();
        player.TabletModel_DeathScreen.gameObject.GetComponent<Animator>().SetTrigger("Revive");
    }
}
