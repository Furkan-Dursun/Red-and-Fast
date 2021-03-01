using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;



public class reklamGoster : MonoBehaviour
{
    private InterstitialAd interstitial;

    void Start()
    {
#if UNITY_ANDROID
        string appId = "******************";
#elif UNITY_IPHONE
        string appId = "******************";
#else
        string appId = "unexpected_platform";
#endif


        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);



    }


    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "*******************";
#elif UNITY_IPHONE
        string adUnitId = "*******************";
#else
        string adUnitId = "unexpected_platform";
#endif
        interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder()
                    .Build();
        interstitial.LoadAd(request);
    }


    // Update is called once per frame
    public void reklamiGoster()
    {
        if (interstitial.IsLoaded())
        {

            interstitial.Show();
        }
    }
}
