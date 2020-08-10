using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public float score = 0;

    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 20;
    private int scoreToNextLevel = 20;

    public Text scoreText;
    private bool isDead = false;
    public DeathMenu deathMenu;


    // Update is called once per frame
    void Update()
    {
        
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += 2*(Time.deltaTime) * difficultyLevel;
        scoreText.text = ((int)score).ToString();
        switch (((int)score))
        {
            case 50:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_50000_km);
               break;
            case 100:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_100000_km);
                break;
            case 500:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_keeping_it_hot);
                break;
            case 1000:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_1000000_km);
                break;
            case 2000:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_feeling_the_speed);
                break;
            case 5000:
                PlayGamesController.UnlockAchievement(GPGSIds.achievement_take_it_up_a_notch);
                break;
            default:
                break;
        }
        
    }

    public void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<FireballMovement>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
     
    }
    public void OnDeath()
    {
        isDead = true;
        PlayGamesController.PostToLeaderBoard((int) score);

        if (PlayerPrefs.GetFloat("Highscore")< score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }      
        deathMenu.ToggleEndMenu(score);
    }

   
   

}
