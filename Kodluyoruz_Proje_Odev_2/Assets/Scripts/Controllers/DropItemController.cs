using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    public DropItemModel _objectType = new DropItemModel();

    private Rigidbody _rb;

    private Vector3 _rbVelocity;
    private Vector3 _rbAngularVelocity;

    bool testBool = false;

    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.GetComponent<PlayerController>().ChangeHitPoint(_objectType.damage);
            //Debug.Log("Hasar Alındı");
        }
        if (other.gameObject.name != "Meteor(Clone)")
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            ObjectPooler.instance.DestroyPool(_objectType._dropObjectType, gameObject);
        }
    }

    private void Update()
    {
        if (GameManager.instance.GetCurrentStateType()==StateType.PreGameState)
        {
            Debug.Log("Fazladan Çalışıyor");
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            ObjectPooler.instance.DestroyPool(_objectType._dropObjectType, gameObject);
        }
        else if (GameManager.instance.GetCurrentStateType()==StateType.PauseGameState && !testBool)
        {
            Debug.Log("Fazladan Çalışıyor");
            FreezeIt();
            testBool = true;
        }
        else if (GameManager.instance.GetCurrentStateType()==StateType.PlayGameState && testBool)
        {
            ThawIt();
            testBool = false;
            Debug.Log("Fazladan Çalışıyor");
        }
        
    }

    public void FreezeIt()
    {
        _rbVelocity = _rb.velocity;
        _rbAngularVelocity = _rb.angularVelocity;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.useGravity = false;
    }

    public void ThawIt()
    {
        _rb.velocity = _rbVelocity;
        _rb.angularVelocity = _rbAngularVelocity;
        _rb.useGravity = true;
        _rbVelocity = Vector3.zero;
        _rbAngularVelocity = Vector3.zero;
    }


}

[System.Serializable]
public class DropItemModel
{
    public PoolObjectType _dropObjectType;
    public int damage = 0;
}




