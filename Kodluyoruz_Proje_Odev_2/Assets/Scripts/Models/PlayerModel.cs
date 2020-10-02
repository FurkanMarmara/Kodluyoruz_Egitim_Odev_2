using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private const int _maxHitPoint = 100;
    private int _hitPoint;
    private int _score;


    public PlayerModel()
    {
        _hitPoint = _maxHitPoint;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void SetHitPoint(int hitPoint)
    {
        _hitPoint = hitPoint;
    }

    public int GetHitPoint()
    {
        return _hitPoint;
    }

    

}


