using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehavior : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Chase,
        Destroying,
    }
    private EnemyState state;

    [SerializeField] List<Transform> transforms;
    NavMeshAgent agent;
    private int rdn;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private PlayerBehavior player;
    [SerializeField] float maxDistChase;
    [SerializeField] float maxAngle;
    [SerializeField] float maxDistWall;
    private GameObject destroyableWall;

    private bool canSeePlayer = false;
    private bool canDestroyWall = false;
    [SerializeField] private float coolDownBefore;
    [SerializeField] private float coolDownAfter;

    private float visibilityCooldown = 3f;
    private float visibilityCooldownTimer = 0f;





    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Patrol;
        ChooseDestination();
    }

    void Update()
    {
        Debug.Log(state);
        RayHittingSomething();

        switch (state)
        {
            case EnemyState.Patrol:
                if (Vector3.Distance(agent.destination, transform.position) <= 1.5f)
                {
                    ChooseDestination();
                }
                if (canSeePlayer)
                {
                    state = EnemyState.Chase;
                }
                if (canDestroyWall)
                {
                    state = EnemyState.Destroying;
                }
                break;

            case EnemyState.Chase:
                agent.SetDestination(playerTransform.position);
                if (!canSeePlayer)
                {
                    state = EnemyState.Patrol;
                }
                break;

            case EnemyState.Destroying:
                if (destroyableWall != null)
                {
                    agent.SetDestination(destroyableWall.transform.position);  //need to add an offset sor ennemy doesn't go around the wall to destroy it
                }

                if (agent.remainingDistance < 1f && coolDownBefore > 0)
                {
                    coolDownBefore -= Time.deltaTime;
                    // Debug.Log(coolDownBefore);
                    if (coolDownBefore <= 0f)
                    {
                        DestroyWall();
                        Invoke(nameof(SetStateToPatrol), coolDownAfter);  //vu que change d'état, passe pas à ligne suivante ?
                        ResetCooldowns();
                    }
                }
                break;
        }
    }

    void SetStateToPatrol()
    {
        state = EnemyState.Patrol;
    }

    void ResetCooldowns()
    {
        coolDownBefore = 2f;
        coolDownAfter = 2f;
    }

    void ChooseDestination()
    {
        rdn = Random.Range(0, transforms.Count);
        agent.SetDestination(transforms[rdn].position);
    }

    IEnumerator PlayerVisibilityCooldown()
    {
        visibilityCooldownTimer = visibilityCooldown;
        while (visibilityCooldownTimer > 0)
        {
            visibilityCooldownTimer -= Time.deltaTime;
            yield return true;
        }
        canSeePlayer = false;
    }


    void RayHittingSomething()
    {
        RaycastHit hit;
        float randomOffset = Random.Range(-1f, 1f) * Mathf.Tan(Mathf.Deg2Rad * maxAngle * 0.5f);  //choose a random point in the desired area (and convert it to rad)
        Vector3 direction = transform.forward + (transform.right * randomOffset);


        Debug.DrawLine(transform.position + Vector3.up * -0.3f, transform.position + Vector3.up * -0.3f + direction * maxDistChase);

        if (Physics.Raycast(transform.position + (Vector3.up * -0.3f), direction, out hit, maxDistChase))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (Vector3.Angle(transform.forward, direction) <= maxAngle)
                {
                    canSeePlayer = true;
                    if (visibilityCooldownTimer <= 0)
                    {
                        StartCoroutine(PlayerVisibilityCooldown());
                    }
                    else
                    {
                        visibilityCooldownTimer = visibilityCooldown;
                    }

                }
            }
            else if (hit.collider.CompareTag("DestroyableWall"))
            {
                if (Vector3.Angle(transform.forward, direction) <= maxAngle)
                {
                    canDestroyWall = true;
                    destroyableWall = hit.collider.gameObject;  //giving the right wall
                }

            }
        }
    }

    void DestroyWall()
    {
        Destroy(destroyableWall);
        Debug.Log("destroy wall");
        canDestroyWall = false;
    }

    void EnnemyAttack()
    {
        if (player.playerLife > 0)
        {
            player.playerLife -= 1;
        }
    }

}
