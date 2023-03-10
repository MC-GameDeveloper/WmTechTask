using Pixelplacement;
using UnityEngine.SceneManagement;

public class GameState : State
{
    private void OnEnable()
    {
        SceneManager.LoadScene(nameof(GameState), LoadSceneMode.Additive);
        
        StateManager.Instance.OnGameFinished.AddListener(HandleGameFinished);
    }

    private void OnDisable()
    {
        SceneManager.UnloadSceneAsync(nameof(GameState));
        
        StateManager.Instance.OnGameFinished.RemoveListener(HandleGameFinished);
    }

    private void HandleGameFinished(bool playerWin)
    {

        StateManager.Instance.playerWon = playerWin;
        StateManager.Instance.TransitionToStateAsync(Utilities.GameState.EndState, 0.25f);
    }
}