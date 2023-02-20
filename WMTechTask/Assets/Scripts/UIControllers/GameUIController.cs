using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
        _quitButton.onClick.RemoveListener(Quit);
    }

    private void Pause()
    {
        _pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void Play()
    {
        _pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void Quit()
    {
        _pauseScreen.SetActive(false);
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
