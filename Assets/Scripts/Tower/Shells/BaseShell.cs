using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShell : MonoBehaviour
{
    private GameObject _target = null;
    public float Speed;
    private float _damage;

    public void SetTarget(GameObject t)
    {
        _target = t;
    }

    public void SetDamage(float dmg)
    {
        _damage = dmg;
    }

    private void Update()
    {
        if (_target == null)
        {
            if(transform.position.y > 0)
            {
                transform.position += Vector3.forward * Time.deltaTime * Speed;                
            }
            else
            {
                Destroy(gameObject);
            }

            return;
        }

        if(Vector3.Distance(transform.position, _target.transform.position) <= 0.1f)
        {
            _target.GetComponent<BaseCreep>().GetHit(_damage);
            Destroy(gameObject);
        }
        else
        {
           transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Speed * Time.deltaTime);
        }
    }
}
