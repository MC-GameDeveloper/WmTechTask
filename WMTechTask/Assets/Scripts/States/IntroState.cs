using Pixelplacement;
using UnityEngine.SceneManagement;

public class IntroState : State
{
    private void OnEnable()
    {
        SceneManager.LoadScene(nameof(IntroState), LoadSceneMode.Additive);
        
        StateManager.Instance.OnStartGame.AddListener(HandleStartGame);
    }
    
    private void OnDisable()
    {
        SceneManager.UnloadSceneAsync(nameof(IntroState));
    }

    private void HandleStartGame()
    {
        StateManager.Instance.TransitionToStateAsync(Utilities.GameState.GameState);
    }
}