using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monetizer : MonoBehaviour
{
    public bool timedBanner;
    public float bannerDuration;
    // Start is called before the first frame update
    void Start()
    {
        AdsCtrl.Instance.ShowBanner();
    }

    private void OnDisable()
    {
        if (!timedBanner)
        {
            AdsCtrl.Instance.HideBanner();
        }
        else
        {
            AdsCtrl.Instance.HideBanner(bannerDuration);
        }
    }
}
