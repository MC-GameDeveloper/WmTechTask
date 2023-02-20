using System;
using UnityEngine;
using UnityEngine.UI;

public class IntroUIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    private void OnEnable()
    {
        startButton.onClick.AddListener(() => {StateManager.Instance.OnStartGame?.Invoke();});
        quitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        quitButton.onClick.RemoveListener(Application.Quit);
    }
}
