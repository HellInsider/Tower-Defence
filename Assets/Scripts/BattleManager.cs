using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject _creepExample;
    public Transform creepTarget;
    public float delay;
    private List<BaseCreep> _creeps = new List<BaseCreep>();
    private short _creepsNum = 6;
    [SerializeField]
    GameLogicManager _logicManager;

    public void StartWave()
    {
        StartCoroutine(CreateWithDelay());
        _creepsNum++;
    }

    IEnumerator CreateWithDelay()
    {
        for (int i = 0; i < _creepsNum; i++)
        {
            Create();
            yield return new WaitForSeconds(delay);
        }
    }

    private void Create()
    {
        GameObject newCreep =  Instantiate(_creepExample, spawnPoint.position, spawnPoint.rotation);
        _creeps.Add(newCreep.GetComponent<BaseCreep>());
        newCreep.GetComponent<BaseCreep>().SetTarget(creepTarget);
        newCreep.GetComponent<BaseCreep>().SetManager(this.GetComponent<BattleManager>());
    }

    public void DeleteUnit(GameObject unit)
    {
        _logicManager.AddMoney(unit.GetComponent<BaseCreep>().GetMoney());
        _creeps.Remove(unit.GetComponent<BaseCreep>());
        Destroy(unit);
        
    }

}
