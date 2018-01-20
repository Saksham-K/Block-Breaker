using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class LevelManager : MonoBehaviour {

    public static int lastScene;
    private InterstitialAd interstitial;

    // Use this for initialization
    void Start()
    {
        #if UNITY_ANDROID
                string appId = "ca-app-pub-3940256099942544~3347511713";
        #elif UNITY_IPHONE
                    string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
                    string appId = "unexpected_platform";
        #endif

                // Initialize the Google Mobile Ads SDK.
                MobileAds.Initialize(appId);
    }

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void BrickDestroy ()
	{
        lastScene = SceneManager.GetActiveScene().buildIndex;
		if (Brick.breakableCount <= 0) {
            LoadWinScene();
		}
	}

    public void LoadWinScene()
    {
        RequestInterstitial();
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        //interstitial.Destroy();
        SceneManager.LoadScene("Win Screen"); 
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetSceneByName("Win Screen").buildIndex==lastScene + 1)
        {
            SceneManager.LoadScene("EndOfGame");
        }
        else
        {
            SceneManager.LoadScene(lastScene + 1);
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(lastScene); 
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        print(request);
        interstitial.LoadAd(request);
    }
}	
