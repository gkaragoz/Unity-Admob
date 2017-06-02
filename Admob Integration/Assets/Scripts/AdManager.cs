using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;
    public string adInterstitialUnitId;
    public string adBannerUnitId;

    public InterstitialAd interstitial;
    public BannerView bannerView;

    void Start()
    {
        instance = this;

        RequestInterstitial();
        RequestBanner();
    }

    public void RequestInterstitial()
    {
        #if UNITY_ANDROID
                adInterstitialUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
        #elif UNITY_IPHONE
                adInterstitialUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adInterstitialUnitId);

        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += InterstitialHandleOnAdLoaded;

        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += InterstitialHandleOnAdFailedToLoad;

        // Called when an ad is clicked.
        interstitial.OnAdOpening += InterstitialHandleOnAdOpened;

        // Called when the user returned from the app after an ad click.
        interstitial.OnAdClosed += InterstitialHandleOnAdClosed;

        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += InterstitialHandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void ShowInterstitial()
    {
        if (interstitial != null)
        {
            if (interstitial.IsLoaded())
            {
                Debug.Log("Interstitial showed");
				interstitial.Show();
            }
        }
    }

    public void InterstitialHandleOnAdLoaded(object sender, EventArgs args)
    {
        print("InterstitialOnAdLoaded event received.");
        // Handle the ad loaded event.
    }

    public void InterstitialHandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        print("InterstitialOnAdFailedToLoad event received.");
        // Handle the ad loaded event.
        RequestInterstitial();
    }

    public void InterstitialHandleOnAdOpened(object sender, EventArgs args)
    {
        print("InterstitialOnAdOpened event received.");
        // Handle the ad loaded event.
    }

    public void InterstitialHandleOnAdClosed(object sender, EventArgs args)
    {
        print("InterstitialOnAdClosed event received.");
        // Handle the ad loaded event.
    }

    public void InterstitialHandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        print("InterstitialOnAdLeavingApplication event received.");
        // Handle the ad loaded event.
    }

    public void RequestBanner()
    {
        #if UNITY_ANDROID
                adBannerUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
        #elif UNITY_IPHONE
                adBannerUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adBannerUnitId, AdSize.Banner, AdPosition.Top);

        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;

        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;

        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;

        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;

        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // If you want to make custom coordinate to show banner usage code in the below.
        // Create a 320x50 banner ad at coordinate (0,50) on screen.
        // bannerView = new BannerView(adUnitId, AdSize.Banner, 0, 50);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        print("OnAdLoaded event received.");
        // Handle the ad loaded event.
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        print("OnAdFailedToLoad event received.");
        // Handle the ad loaded event.
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        print("OnAdOpened event received.");
        // Handle the ad loaded event.
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        print("OnAdClosed event received.");
        // Handle the ad loaded event.
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        print("OnAdLeavingApplication event received.");
        // Handle the ad loaded event.
    }

    public void ShowBanner()
    {
        Debug.Log("Banner showed");
        bannerView.Show();
    }
    
    public void HideBanner()
    {
        Debug.Log("Banner hide");
        bannerView.Hide();
    }
}
