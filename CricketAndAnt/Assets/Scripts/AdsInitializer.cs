using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener , IUnityAdsLoadListener, IUnityAdsShowListener 
{

    [SerializeField] string _androidGameId;
    [SerializeField] string _IOsGameId;
    [SerializeField] bool _testMode = true;
    string _GameId;

    public void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _GameId = _androidGameId;
        Advertisement.Initialize(_GameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        LoadIntertitialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity ads initializ failed: {error.ToString()} - {message}");
    }



    public void LoadIntertitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Unity ad initializ failed:{placementId} {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("ad show fail");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("ad show click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;
    }
}
