using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    //[SerializeField]
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointIndex = 0;  // điểm bắt đầu

    private void Awake()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        waveConfig = enemySpawner.GetWaveConfig();
    }

    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position; // vị trí là Waypoint 0
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);    // điểm cuối => xóa
        }
    }
}
