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
    NavMeshAgent agent;
    private int rdn;

    [SerializeField] private Transform playerTransform;
    [SerializeField] float maxDist;
    [SerializeField] float maxAngle;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Patrol;
        ChooseDestination();
    }

    void Update()
    {
        // Debug.Log(state);

        switch (state)
        {
            case EnemyState.Patrol:
                if (Vector3.Distance(agent.destination, transform.position) <= 1.5f)
                {
                    ChooseDestination();
                }
                if (CanSeePlayer())
                {
                    state = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                agent.SetDestination(playerTransform.position);
                if (!CanSeePlayer())
                {
                    state = EnemyState.Patrol;
                }
                break;


        }


    }

    void ChooseDestination()
    {
        rdn = Random.Range(0, transforms.Count);
        agent.SetDestination(transforms[rdn].position);
        Debug.Log(rdn);
    }

    bool CanSeePlayer()
    {
        //faire un raycast depuis l'ennemy vers le joueur, il faut donc lui passer le joueur (transform)
        //physics.raycast pour condition, compare tag

        RaycastHit hit;
        Vector3 playerDistance = playerTransform.position - transform.position;
        if (Physics.Raycast(transform.position+(Vector3.up * 0.3f), playerDistance, out hit, maxDist))
        {
            //check collider
            if (hit.collider.CompareTag("Player"))
            {
                //check angle 
                if (Vector3.Angle(transform.forward, playerDistance) <= maxAngle)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
