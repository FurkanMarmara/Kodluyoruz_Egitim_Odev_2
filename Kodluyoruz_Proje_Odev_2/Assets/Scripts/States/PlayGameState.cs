using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayGameState : MonoBehaviour,IState
{
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private DropController _dropController;



    public void Enter()
    {
        enabled = true;
        _player.enabled = true;
        _dropController.enabled = true;

        Debug.Log("Entered GameState");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.SetState(StateType.PauseGameState);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GameState");
        enabled = false;
        _player.enabled = false;
        _dropController.enabled = false;
    }

}
