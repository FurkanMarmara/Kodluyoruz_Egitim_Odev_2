using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.2f;
    [SerializeField]
    private Text _scoreText;
    private PlayerModel _player;
    [SerializeField]
    private HealthBarController _healthBar;



    private Coroutine _scoreCoroutine;

    private Rigidbody rb;

    private void Start()
    {
        _player = new PlayerModel();
        rb = gameObject.transform.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _scoreCoroutine = StartCoroutine(IncreaseScoreNumerator());
    }
    private void OnDisable()
    {
        StopCoroutine(_scoreCoroutine);
    }

    private void FixedUpdate()
    {
        MoveIt();
    }

    public void ChangeHitPoint(int damage)
    {
        _player.SetHitPoint(_player.GetHitPoint() - damage);
        _healthBar.SetHealthBar(_player.GetHitPoint());
        if (_player.GetHitPoint()<=0)
        {
            Die();
        }
        
    }

    private void MoveIt()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x<2.4f)
            {
                gameObject.transform.position += new Vector3(_speed, 0, 0);
            }
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x>-2.4f)
            {
                gameObject.transform.position -= new Vector3(_speed, 0, 0);
            }
          
        }
    }

    private void IncreaseScore()
    {
        _player.SetScore(_player.GetScore()+1);
        _scoreText.text = _player.GetScore().ToString();
    }

    private void Die()
    {
        Debug.Log("Öldün");
        GameManager.instance.SetState(StateType.PreGameState);
        Reset();
    }

    public void Reset()
    {
        _player.SetHitPoint(100);
        _player.SetScore(0);
        _healthBar.SetHealthBar(_player.GetHitPoint());
        _scoreText.text = _player.GetScore().ToString();
    }

    IEnumerator IncreaseScoreNumerator()
    {
        var waitTime = new WaitForSeconds(0.5f);
        while (true)
        {
            yield return waitTime;
            IncreaseScore();
        }
        
    }

}
