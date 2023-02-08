using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsCtrl : MonoBehaviour
{
    public static AdsCtrl Instance;
    public string Android_AdMob_Banner_ID;

    public bool testMode;

    BannerView bannerView;
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
        bannerView.Show();
    }

    public void HideBanner()
    {
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

    private void OnDisable()
    {
        bannerView.Destroy();
    }

    private void OnEnable()
    {
        RequestBanner();
    }
}
