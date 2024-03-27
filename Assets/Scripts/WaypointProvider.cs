<<<<<<< Updated upstream
using System.Collections;
=======
>>>>>>> Stashed changes
using System.Collections.Generic;
using UnityEngine;

public class WaypointProvider : MonoBehaviour
{
    private static WaypointProvider instance;
    public static WaypointProvider Instance => instance;

<<<<<<< Updated upstream
    List<Transform> waypoints = new List<Transform>();

=======
    private List<Transform> waypoints = new List<Transform>();
>>>>>>> Stashed changes
    private void Awake()
    {
        instance = this;
    }
<<<<<<< Updated upstream

    // Start is called before the first frame update
    void Start()
=======
    private void Start()
>>>>>>> Stashed changes
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i));
        }
    }

    public Transform GetNextWaypoint(Transform current = null)
    {
<<<<<<< Updated upstream
        if(current == null)
            return waypoints[0];

        int index = waypoints.IndexOf(current);
        index++;
=======
        if (current==null)
        {
            return waypoints[0];
        }
        int index = waypoints.IndexOf(current);
        index++;

>>>>>>> Stashed changes
        if (index == waypoints.Count) return null;

        return waypoints[index];
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
}
