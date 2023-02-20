using System;
using UnityEngine;
using UnityEngine.UI;

public class IntroUIController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    private void OnEnable()
    {
        _startButton.onClick.AddListener(() => {StateManager.Instance.OnStartGame?.Invoke();});
        _quitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _quitButton.onClick.RemoveListener(Application.Quit);
    }
}
