using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCreep : MonoBehaviour
{
    public GameObject Target;

    public float healthPoints;
    public float moveSpeed;
    public short money;
    public float damage;

    private float _curHealth;
    private float _curMoveSpeed;

    private NavMeshAgent _agent;
    private BattleManager _manager;
    [SerializeField] HealthBar _healthBar;
    [SerializeField] GameObject _creepBody;

    private void Awake()
    {
        _curHealth = healthPoints;
        _curMoveSpeed = moveSpeed;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, Target.transform.position) <= 1)
        {
            Debug.Log("Attack tower");
            Target.GetComponent<BaseCastle>().GetHit(damage);
            _manager.DeleteUnit(gameObject);
        }
    }

    public void GetHit(float dmg)
    {
        _curHealth -= dmg;
        _healthBar.ChangeHP(healthPoints, _curHealth);
        if (_curHealth <= 0) 
        {
            _manager.DeleteUnit(gameObject);
        }
    }

    public void SetTarget(GameObject _t)
    {
        Target = _t;
        _agent.SetDestination(Target.transform.position);
    }

    public void SetManager(BattleManager man)
    {
        _manager = man;
    }

    public short GetMoney()
    {
        return money;
    }

    public void PlayWinAnimation()
    {
        _creepBody.GetComponent<Animator>().SetBool("Win", true);
    }


}
