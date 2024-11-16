using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class AdsController : MonoBehaviour , IUnityAdsListener
{
    [SerializeField] GameController gameController;
    void Start()
    {
        Advertisement.Initialize("5732089"); //Game ID for Android
        Advertisement.AddListener(this);
        ShowBanner();
    }

    public void PlayRewardAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded Ad is not ready");
        }
    }
    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        } else { StartCoroutine(TryBanner()); }
    }

    IEnumerator TryBanner()
    {
        yield return new WaitForSeconds(1f);
        ShowBanner();
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId) {}

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Errors " + message);
    }

    public void OnUnityAdsDidStart(string placementId) {}

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //Reward the player over here
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Rewards");
            GameController.ContinueAfterAd();
            if(GameController.lastHitCactus)
            {
                Destroy(GameController.lastHitCactus);
            }
            gameController.ResumeGame();
        }
    }
}
