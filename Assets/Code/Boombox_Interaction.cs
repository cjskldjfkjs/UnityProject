using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boombox_Interaction : MonoBehaviour
{
    [SerializeField]
    private Animator pauseButtonAnimator;
    private bool isPauseButtonPressed;
    [Space]
    [SerializeField]
    private Animator boomBoxAnimator;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject boomboxCore;
    private Collider childBoxcolider;
    RaycastHit hit;
    
    void Start()
    {
        childBoxcolider = boomboxCore.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
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

    public void SelectedIdle()
    {
    }
    public void BoomboxPressed()
    {
        if (boomBoxAnimator.GetBool("IsExitPressed"))
        { 
            boomBoxAnimator.SetBool("IsPressed", false);
            boomBoxAnimator.SetBool("IsExitPressed", false);
        }

        else if (!boomBoxAnimator.GetBool("IsPressed"))
            boomBoxAnimator.SetBool("IsPressed", true);

        else
        {
            childBoxcolider.enabled = false;
            boomBoxAnimator.SetBool("IsSelected", true);
            boomBoxAnimator.SetBool("IsPressed", false);
        }
    }
    public void PressedPrevButton()
    {
        if (!boomBoxAnimator.GetBool("IsPrevPressed"))
            boomBoxAnimator.SetBool("IsPrevPressed", true);
        else
            boomBoxAnimator.SetBool("IsPrevPressed", false);
    }
    public void PressedStop()
    {
        if (!boomBoxAnimator.GetBool("IsStopPressed"))
            boomBoxAnimator.SetBool("IsStopPressed", true);
        else
            boomBoxAnimator.SetBool("IsStopPressed", false);
    }
    public void PressedNextButton()
    {
        if (!boomBoxAnimator.GetBool("IsNextPressed"))
            boomBoxAnimator.SetBool("IsNextPressed", true);
        else
            boomBoxAnimator.SetBool("IsNextPressed", false);
    }
    public void PressedPlayButton()
    {
        if(!boomBoxAnimator.GetBool("IsPlayPressed"))
            boomBoxAnimator.SetBool("IsPlayPressed", true);
        else
            boomBoxAnimator.SetBool("IsPlayPressed", false);
    }
    public void PressedSettingsButton()
    {
        if (!boomBoxAnimator.GetBool("IsSettingsPressed"))
            boomBoxAnimator.SetBool("IsSettingsPressed", true);
        else
            boomBoxAnimator.SetBool("IsSettingsPressed", false);
    }
    public void PressedExitButton()
    {
        childBoxcolider.enabled = true;
        if (!boomBoxAnimator.GetBool("IsExitPressed"))
            boomBoxAnimator.SetBool("IsExitPressed", true);
        else
            boomBoxAnimator.SetBool("IsExitPressed", false);
    }
    public void PauseButtonPressed()
    {
        if (!isPauseButtonPressed)
        {
            pauseButtonAnimator.SetTrigger("PuaseButtonPressed");
            isPauseButtonPressed = true;
        }

        else
        {
            pauseButtonAnimator.SetTrigger("ExitPauseBatton");
            isPauseButtonPressed = false;
        }
    }
}

