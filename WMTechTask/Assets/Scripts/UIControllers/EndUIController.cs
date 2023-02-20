using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    [SerializeField] private Button _playAgain;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TMP_Text winText;
    private void OnEnable()
    {
        _playAgain.onClick.AddListener(() => {StateManager.Instance.OnStartGame?.Invoke();});
        _quitButton.onClick.AddListener(() => {StateManager.Instance.GoToMainMenu();});
        
        winText.text = $"You {(StateManager.Instance.playerWon? "Won!" : "Lost.")}";
    }
}
