using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameState : MonoBehaviour, IState
{
    public void Enter()
    {
        enabled = true;
        Debug.Log("Entered PauseGameState");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.instance.SetState(StateType.PlayGameState);
        }

    }
    public void Exit()
    {
        enabled = false;
        Debug.Log("Exit PauseGameState");
    }
}
