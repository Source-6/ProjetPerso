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
        Attacking,
        Hurting,
    }
    private EnemyState state;

    [Header("Path")]
    [Space]
    [SerializeField] List<Transform> transforms;
    [SerializeField] Transform startingPos;
    NavMeshAgent agent;
    private int rdn;

    [Header("Player")]
    [Space]

    [SerializeField] private GameObject player;
    private bool canSeePlayer = false;
    private bool canAttack = false;
    [SerializeField] float maxDistChase;
    [SerializeField] float maxAngle;

    [Header("Destroy")]
    [Space]
    [SerializeField] float maxDistWall;
    private GameObject destroyableWall;
    private GameObject destroyableDoor;
    private bool canDestroyDoor;
    private bool canDestroyWall = false;

    [Header("Traps")]
    [Space]

    [SerializeField] private int enemyLife;
    private bool isHurting;
    [SerializeField] private GameObject trap;




    [Header("Cooldowns")]
    [Space]
    [SerializeField] private float coolDownBefore;
    [SerializeField] private float coolDownAfter;
    private float visibilityCooldown = 3f;
    private float visibilityCooldownTimer = 0f;
    private float attackCooldown = 3f;
    private float attackCooldownTimer = 0f;


    void Awake()
    {
        transform.position = startingPos.position;
    }


    public void Initialize()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Patrol;
        ChooseDestination();
    }

    void Update()
    {
        RayHittingSomething();
        Debug.Log(state);

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
                if (canDestroyWall || canDestroyDoor)
                {
                    state = EnemyState.Destroying;
                }
                if (isHurting)
                {
                    state = EnemyState.Hurting;
                }
                break;

            case EnemyState.Chase:
                agent.SetDestination(player.transform.position +transform.forward*2);
                if (!canSeePlayer)
                {
                    state = EnemyState.Patrol;
                }
                if (isHurting)
                {
                    StartCoroutine(SetStateTo(EnemyState.Hurting));
                }
                if (canAttack)
                {
                    StartCoroutine(SetStateTo(EnemyState.Attacking));
                }
                break;

            case EnemyState.Attacking:
                agent.SetDestination(player.transform.position);
                EnnemyAttack();
                break;

            case EnemyState.Destroying:
                if (canSeePlayer)
                {
                    state = EnemyState.Chase;
                }
                if (destroyableWall != null)
                {
                    agent.SetDestination(destroyableWall.transform.position);  //need to add an offset sor ennemy doesn't go around the wall to destroy it
                }
                else if (destroyableDoor != null)
                {
                    agent.SetDestination(destroyableDoor.transform.position);
                }

                if (agent.remainingDistance < 1f && coolDownBefore > 0)
                {
                    coolDownBefore -= Time.deltaTime;
                    if (coolDownBefore <= 0f)
                    {
                        if (canDestroyDoor)
                        {
                            canDestroyWall = false;
                            DestroyObject(destroyableDoor);
                        }
                        else if (canDestroyWall)
                        {
                            canDestroyDoor = false;
                            DestroyObject(destroyableWall);
                        }
                        StartCoroutine(SetStateTo(EnemyState.Patrol));
                        // Invoke(nameof(SetStateTo(EnemyState.Patrol)), coolDownAfter);  //vu que change d'état, passe pas à ligne suivante ?
                        // ResetCooldowns();
                    }

                }
                break;

            case EnemyState.Hurting:
                agent.SetDestination(transform.position);
                GetsStuck();

                //no other state changes bc enemy should be stuck here ??
                break;

        }
    }

        //Coroutines --
    IEnumerator SetStateTo(EnemyState enemyState)
    {
        yield return new WaitForSeconds(coolDownAfter);
        state = enemyState;
        ResetCooldowns();
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



    void ResetCooldowns()
    {
        coolDownBefore = 2f;
        coolDownAfter = 2f;
    }

    void ChooseDestination()  //modify this one to create path
    {
        rdn = Random.Range(0, transforms.Count);
        agent.SetDestination(transforms[rdn].position);
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
            else if (hit.collider.CompareTag("Door"))
            {
                if (Vector3.Angle(transform.forward, direction) <= maxAngle)
                {
                    canDestroyDoor = true;
                    destroyableDoor = hit.collider.gameObject;  //giving the right door
                }

            }
        }
    }

    void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
        Debug.Log("destroy wall");
        canDestroyWall = false;
        canDestroyDoor = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TrapItem>())
        {
            isHurting = true;
            Debug.Log(isHurting);

        }
        if (other.gameObject.tag == "DistancePlayer" && !isHurting)
        {
            canAttack = true;
        }
    }

    void GetsHurt(int damage)
    {
        if (enemyLife > 0)
        {
            enemyLife -= damage;
            Debug.Log(enemyLife);
        }
    }

    void GetsStuck()
    {
        transform.Rotate(0,0,90);
    }

    void EnnemyAttack()
    {
        Debug.Log("ennemy attack");
        if (player.GetComponent<PlayerBehavior>().playerLife > 0)
        {
            if (attackCooldownTimer >= 0 )
                {
                    attackCooldownTimer -= Time.deltaTime;
                    player.GetComponent<PlayerBehavior>().playerLife --;
                }
            else
            {
                attackCooldownTimer = attackCooldown;
            }
        }
    }

}
