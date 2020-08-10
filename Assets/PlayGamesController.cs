using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayGamesController : MonoBehaviour
{
   




    private void Start()
    {
        AuthenticateUser();
    }

    void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                
                Debug.Log("Logged in to Google Play Games Services");

            }
            else
            {
                Debug.LogError("Unable to sign in to Google Play Games Services");
            }

            UnlockAchievement(GPGSIds.achievement_login);

        });
       


    }

    public static void PostToLeaderBoard(int highScore)
    {
        Social.ReportScore(highScore, GPGSIds.leaderboard_high_score, (bool success) =>
        {
            if (success)
            {
                
                Debug.Log("Posted new score to leaderboard");
            }
            else
            {
                Debug.LogError("Unable to post new score to leaderboard");
            }

           
        });
    }

    
    public static void ShowLeaderboadUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }
   
   
    public void OnButtonShowLeaderboard()
    {
        Debug.Log("Showing leaderboard");
        PlayGamesController.ShowLeaderboadUI();
    }

    public void ShowAchievementUI()
    {
        Social.ShowAchievementsUI();
    }

    public static void UnlockAchievement(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {
            Debug.Log("Achievement Unlocked" + success.ToString());
        });
    }

    
        
    
    
    
   



}
