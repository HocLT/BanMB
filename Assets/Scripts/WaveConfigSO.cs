using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField]
    Transform pathPrefab;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    List<GameObject> enemyPrefabs;

    public Transform GetStartingWayPoint() 
    { 
        return pathPrefab.GetChild(0); 
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> list = new List<Transform>();
        foreach (Transform item in pathPrefab)
        {
            list.Add(item);
        }
        return list;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
}
