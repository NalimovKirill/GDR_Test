using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    [SerializeField] private Transform _moveableTarget;
    [SerializeField] private GameObject _waypointPrefab;

    private List<Transform> _waypoints = new List<Transform>();

    private int _nextWayPointIndex;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var waypoint = Instantiate(_waypointPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

            waypoint.transform.parent = gameObject.transform;
        }
    }
}
