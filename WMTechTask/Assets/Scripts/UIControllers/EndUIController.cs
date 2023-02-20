using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    [SerializeField] private Button _playAgain;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TMP_Text _winText;
    private void OnEnable()
    {
        _playAgain.onClick.AddListener(() => {StateManager.Instance.OnStartGame?.Invoke();});
        _quitButton.onClick.AddListener(() => {StateManager.Instance.GoToMainMenu();});
        
        _winText.text = $"You {(StateManager.Instance.playerWon? "Won!" : "Lost.")}";
    }
}
