using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ReviveAfterAd : MonoBehaviour, IUnityAdsInitializationListener
{
    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("5573073", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdForRevive()
    {
        Advertisement.Show("Rewarded_Android");
    }
}
