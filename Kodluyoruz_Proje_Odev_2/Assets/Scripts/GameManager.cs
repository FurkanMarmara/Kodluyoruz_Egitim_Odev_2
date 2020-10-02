using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<State> gameStates = new List<State>();

    #region Singleton 
    public static GameManager instance;
    public GameManager()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    private static IState _currentState;
    private StateType _currentStateType;


    private void Start()
    {
        SetState(StateType.PreGameState);
        
    }

    #region StateMachine
    public void SetState(StateType stateType)
    {
        _currentStateType = stateType;

        IState nextState = gameStates.FirstOrDefault(x => x._stateType == stateType)._stateScript as IState;


        if (_currentState == null)
        {
            _currentState = nextState;
            _currentState.Enter();
        }
        else
        {
            _currentState.Exit();
            _currentState = nextState;
            nextState.Enter();
        }

    }
    #endregion

    public StateType GetCurrentStateType()
    {
        return _currentStateType;
    }
   
   
}

[System.Serializable]
public class State
{
    public MonoBehaviour _stateScript;
    public StateType _stateType;
}

public enum StateType
{
    PreGameState,
    PlayGameState,
    PauseGameState,
    EndGameState
}
