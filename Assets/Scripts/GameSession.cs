using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;


    void Awake()
    {
        // FindObjectsOfType create of array 
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        //Awake is started when this class is brought to life, when we push play button and then dye
        if (numGameSessions > 1)
        {
            //we destroy on load if there is two objects of GameSession and we destroy newest
            Destroy(gameObject);
        }
        else
        {
            //stick around when we dye or level changes
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLife.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLife > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playerLife--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        // it doesn't work because it doesn't have Singleton so it is good to move canvas to gameSession
        livesText.text = playerLife.ToString();
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        //destroy this instance GameSession.cs if someone plays again everything is new without scores and so on
        Destroy(gameObject);
    }
}

// good to make game session to handle score and lives