using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    PlayerController player;
    Transform target;
    ShootingHandler playerShootingHandler;
    bool canAttack = true;
    bool isTriggered = false;
    [SerializeField] float turnSpeed = 10;
    [SerializeField] float triggerDistance = 20;
    [SerializeField] float damageDelay = 1;
    NavMeshAgent agent;
    [SerializeField] EnemyAttack shootingHandler;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerShootingHandler = player.GetComponent<ShootingHandler>();
        agent = GetComponent<NavMeshAgent>();
        shootingHandler = GetComponent<EnemyAttack>();

        playerShootingHandler.onShootEvent += OnPlayerShoot;
    }

    void Update()
    {
        if(isTriggered)
        {
            FollowTarget();
        }

        else if(Vector3.Distance(transform.position, player.transform.position) < triggerDistance)
        {
            target = player.transform;
            isTriggered = true;
        }
    }

    void OnPlayerShoot(object sender, EventArgs e)
    {
        target = player.transform;
        FollowTarget();
    }

    void OnDamageTaken()
    {
        foreach(EnemyBehaviour enemy in EnemyHandler.Instance.activeEnemies)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) < triggerDistance)
            {
                target = enemy.transform;
                isTriggered = true;
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void FollowTarget()
    {
        print("Attack");
        FaceTarget();
        agent.SetDestination(target.transform.position);

        if(Vector3.Distance(transform.position, target.transform.position) < agent.stoppingDistance)
        {
            if(canAttack)
            {
                StartCoroutine(DamagePlayer());
            }
        }
    }

    IEnumerator DamagePlayer()
    {
        canAttack = false;
        yield return new WaitForSeconds(damageDelay);
        shootingHandler.StartShot();
        yield return new WaitForSeconds(damageDelay / 2);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }
} 