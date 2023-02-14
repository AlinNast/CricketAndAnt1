using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsCtrl : MonoBehaviour
{
    public static AdsCtrl Instance;
    public string Android_AdMob_Banner_ID;
    public string Android_AdMob_Interstitial_ID;

    public bool showBanner, showInterstitial;

    public bool testMode;

    BannerView bannerView;
    InterstitialAd InterstitialAd;

    AdRequest request;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RequestBanner()
    {
        if (testMode)
        {
            bannerView = new BannerView(Android_AdMob_Banner_ID, AdSize.Banner, AdPosition.Top);
        }
        else
        {
            // cove for live ads
        }

        AdRequest adRequest = new AdRequest.Builder().Build();

        bannerView.LoadAd(adRequest);
        HideBanner();   
    }

    public void ShowBanner()
    {
        if (showBanner)
        {
            bannerView.Show();
        }
    }
        

    public void HideBanner()
    {
        if (showBanner)
            bannerView.Hide();
    }

    public void HideBanner(float duration)
    {
        StartCoroutine("HideBannerRoutine", duration);
    }

    IEnumerator HideBannerRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        bannerView.Hide();
    }

    void RequestInterstitialAd()
    {
        if (testMode)
        {
            InterstitialAd = new InterstitialAd(Android_AdMob_Interstitial_ID);

        }
        else
        {
            // code for live ad
        }
        request = new AdRequest.Builder().Build();
        InterstitialAd.LoadAd(request);

        InterstitialAd.OnAdClosed += HandleAdClose;
    }

    public void HandleAdClose(object sernder, EventArgs args)
    {
        InterstitialAd.Destroy();
        RequestInterstitialAd();
    }

    public void ShowIntertitialAd()
    {
        if (showInterstitial)
        {
            if (InterstitialAd.IsLoaded())
            {
                InterstitialAd.Show();
            }
        }
        
    }

    private void OnDisable()
    {
        bannerView.Destroy();

        InterstitialAd.Destroy();
    }

    private void OnEnable()
    {
        if(showBanner)
            RequestBanner();
        if(showInterstitial)
            RequestInterstitialAd();
    }
}
