using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreep : MonoBehaviour
{
    public Transform Target;

    public float healthPoints;
    public float moveSpeed;
    public short money;

    private float _curHealth;
    private float _curMoveSpeed;

    private NavMeshAgent _agent;
    private BattleManager _manager;

    private void Awake()
    {
        _curHealth = healthPoints;
        _curMoveSpeed = moveSpeed;
        _agent = GetComponent<NavMeshAgent>();
    }

    public void GetHit(float dmg)
    {
        _curHealth -= dmg;
        if (_curHealth <= 0) 
        {
            _manager.DeleteUnit(gameObject);
        }
    }

    public void SetTarget(Transform _t)
    {
        Target = _t;
        _agent.SetDestination(Target.position);
    }

    public void SetManager(BattleManager man)
    {
        _manager = man;
    }

    public short GetMoney()
    {
        return money;
    }


}
