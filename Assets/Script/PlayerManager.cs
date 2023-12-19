using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public static Vector2 lastCheckPointPos = new Vector2(-8,0);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject[] playerPrefabs;
    int characterIndex;
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        virtualCamera.m_Follow = player.transform;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0); // luu gia tri coins va khong reset coins khi choi van moi(co the de comment)
        isGameOver = false;
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GamePause()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
