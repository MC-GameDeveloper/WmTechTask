using Pixelplacement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//A singleton pattern used to keep game state logic separate from gameplay logic
public class StateManager : StateMachine
{
    //Events
    [HideInInspector]
    public UnityEvent OnStartGame;
    [HideInInspector]
    public UnityEvent OnPause;
    [HideInInspector]
    public UnityEvent<bool> OnGameFinished;
    
    //Public
    public bool playerWon;
    
    //Private
    [SerializeField] private Image fadeScreen;

    //Singleton
    private static StateManager _instance;

    public static StateManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToStateAsync(Utilities.GameState state, float delay = 0)
    {
        Tween.Color(fadeScreen, Vector4.zero, new Color(0, 0, 0, 1f), 0.5f, delay, Tween.EaseLinear, 
            startCallback: () =>
            {
                fadeScreen.enabled = true;
            },
            completeCallback: () =>
            {
                ChangeState((int)state);
                Tween.Color(fadeScreen, new Color(0, 0, 0, 1f), Vector4.zero, 0.5f, 0, Tween.EaseLinear, completeCallback: () => { fadeScreen.enabled = false;});
            });
    }

    public void GoToMainMenu()
    {
        TransitionToStateAsync(Utilities.GameState.StartState);
    }
}