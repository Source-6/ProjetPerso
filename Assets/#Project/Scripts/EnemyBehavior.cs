using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehavior : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Chase,
    }
    private EnemyState state;

    [SerializeField] List<Transform> transforms;
    private int index = 0;
    NavMeshAgent agent;

    [SerializeField] float maxDist;
    [SerializeField] float maxAngle;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Patrol;
        transform.position = transforms[index].position;
    }

    void Update()
    {
        ChooseDestination();
    }

    void ChooseDestination()
    {
        while (index < transforms.Count)
        {
            index++;
            if (index == transforms.Count) {
                index = 0;
            }
        }
        
    }
}
