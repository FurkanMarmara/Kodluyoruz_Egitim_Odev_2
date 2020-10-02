using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    [SerializeField]
    private List<PoolObjectType> _drops = new List<PoolObjectType>();

    private Coroutine _dropCoroutine;

    private float _timeDelay = 0;


    private void OnEnable()
    {
        _dropCoroutine = StartCoroutine(SpawnDropItem(0.6f,_timeDelay));
    }

    private void OnDisable()
    {
        StopCoroutine(_dropCoroutine);
    }

    IEnumerator SpawnDropItem(float time,float delay)
    {
        var waitTime = new WaitForSeconds(time);
        var _pauseDelayTime = new WaitForSeconds(delay);

        yield return _pauseDelayTime;
        Debug.Log(_timeDelay+"TimeDelay");
        while (true)
        {
            ObjectPooler.instance.SpawnFromPool(_drops[Random.Range(0, _drops.Count)], new Vector3(Random.Range(-2.2f, 2.2f), 7, 0), Quaternion.identity);
            yield return waitTime;
        }

    }

    private void Update()
    {
        CalculateTimeDelay();
    }

    private void CalculateTimeDelay()
    {
        _timeDelay -= Time.deltaTime;
        if (_timeDelay<=0)
        {
            _timeDelay = 0.6f;
        }
    }


}

