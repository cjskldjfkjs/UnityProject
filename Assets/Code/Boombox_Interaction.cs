using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombox_Interaction : MonoBehaviour
{
    [SerializeField]
    private Animator boomBoxAnimator;
    RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            { 
                switch(hit.collider.gameObject.tag)
                    { 
                    case"PressedBoombox":
                        BoomboxPressed();
                            break;
                    
                    case "PressedPrevButton":
                        PressedPrevButton();
                        break;

                    case "PressedStop":
                        PressedStop();
                        break;
                    
                    case "PressedNextButton":
                        PressedNextButton();
                        break;

                    case "PressedPlayButton":
                        PressedPlayButton();
                        break;

                    case "PressedSettingsButton":
                        PressedSettingsButton();
                        break;

                    case "PressedExitButton":
                        PressedExitButton();
                        break;
                }   
            }
        }
    }

    private void BoomboxPressed()
    { 
        boomBoxAnimator.SetBool("IsPressed", true);
    }
    private void PressedPrevButton()
    {
        boomBoxAnimator.SetBool("IsPrevPressed", true);
    }
    private void PressedStop()
    {
        boomBoxAnimator.SetBool("IsStopPressed", true);
    }
    private void PressedNextButton()
    {
        boomBoxAnimator.SetBool("IsNextPressed", true);
    }
    private void PressedPlayButton()
    {
        boomBoxAnimator.SetBool("IsPlayPressed", true);
    }
    private void PressedSettingsButton()
    {
        boomBoxAnimator.SetBool("IsSettingsPressed", true);
    }
    private void PressedExitButton()
    {
        boomBoxAnimator.SetBool("IsExitPressed", true);
    }
}
