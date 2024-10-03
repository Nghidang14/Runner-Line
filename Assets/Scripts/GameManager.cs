using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector3 originalCamPos;
    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject spawner;
    public GameObject bgParticle;

    public static GameManager instance;
    public bool gameStarted = false;
    public GameObject player;
    int lives = 2;
    int score = 0;
    public Text scoreText;
    public Text livesText;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalCamPos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gameplayUI.SetActive(true);
        spawner.SetActive(true);
        bgParticle.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);

        Invoke("ReloadLevel", 1.5f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;

            livesText.text = "Lives: " + lives;
        }
    }

    public void UpdateScore()
    {
        score++;

        scoreText.text = "Score: " + score;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Shake()
    {
        StartCoroutine(ICameraShake());
    }

    IEnumerator ICameraShake()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
