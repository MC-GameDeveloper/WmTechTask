using Pixelplacement;
using UnityEngine;
using UnityEngine.Events;

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

    public void GoToMainMenu()
    {
        ChangeState((int)Utilities.GameState.StartState);
    }
}