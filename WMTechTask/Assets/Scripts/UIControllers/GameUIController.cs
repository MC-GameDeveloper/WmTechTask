using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button playButton;
    public Button quitButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(Play);
        quitButton.onClick.RemoveListener(Quit);
    }

    private void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void Play()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void Quit()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
        StateManager.Instance.GoToMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
