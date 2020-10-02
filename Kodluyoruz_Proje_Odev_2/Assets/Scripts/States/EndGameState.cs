using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : MonoBehaviour, IState
{
    [SerializeField]
    private GameObject _endGamePanel;

    public void Enter()
    {
        Debug.Log("Entered End Game State");
        enabled = true;
        _endGamePanel.SetActive(true);
    }

    public void Exit()
    {
        enabled = false;
        _endGamePanel.SetActive(false);
        
    }

    public void PlayAgain()
    {
        GameManager.instance.SetState(StateType.PlayGameState);
    }
}
