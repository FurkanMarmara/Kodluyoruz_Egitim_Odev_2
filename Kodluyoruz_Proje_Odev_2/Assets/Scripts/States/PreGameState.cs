using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameState : MonoBehaviour, IState
{
    [SerializeField]
    private GameObject _waitScreen;
    [SerializeField]
    private Text _bestScoreText;
    [SerializeField]
    private Text _playText;

    Coroutine _animCoroutine;

    public void Enter()
    {
        enabled = true;
        _waitScreen.SetActive(true);
        _animCoroutine = StartCoroutine(PlayTextAnimate());
        Debug.Log("Entered PreGameState");
    }

    public void Exit()
    {
        Debug.Log("Exit PreGameState");
        _waitScreen.SetActive(false);
        StopCoroutine(_animCoroutine);
        enabled = false;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.SetState(StateType.PlayGameState);
        }
    }


    IEnumerator PlayTextAnimate()
    {
        float t = 0;

        while (true)
        {
            var val = Mathf.PingPong(t,0.5f) + 0.5f;
            _playText.color = new Color(1, 1, 1, val);
            yield return null;
            t += Time.deltaTime;
        }
    }


    
}
