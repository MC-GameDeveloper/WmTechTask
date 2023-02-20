using Pixelplacement;
using UnityEngine.SceneManagement;

public class EndState : State
{
    private void OnEnable()
    {
        SceneManager.LoadScene(nameof(EndState), LoadSceneMode.Additive);
    }
    
    private void OnDisable()
    {
        SceneManager.UnloadSceneAsync(nameof(EndState));

    }
}