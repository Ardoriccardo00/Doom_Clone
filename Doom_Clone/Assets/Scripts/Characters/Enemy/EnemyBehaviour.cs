using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    PlayerController player;
    Health playerHealth;
    ShootingHandler playerShootingHandler;
    bool canAttack = true;
    [SerializeField] float triggerDistance = 20;
    [SerializeField] int damage = 10;
    [SerializeField] float damageDelay = 1;
    NavMeshAgent agent;
    [SerializeField] EnemyAttack shootingHandler;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerHealth = player.GetComponent<Health>();
        playerShootingHandler = player.GetComponent<ShootingHandler>();
        agent = GetComponent<NavMeshAgent>();
        shootingHandler = GetComponent<EnemyAttack>();

        playerShootingHandler.onShootEvent += OnPlayerShoot;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < triggerDistance)
        {
            FollowPlayer();
        }
    }

    void OnPlayerShoot(object sender, EventArgs e)
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        print("Attack");
        agent.SetDestination(player.transform.position);

        if(Vector3.Distance(transform.position, player.transform.position) < agent.stoppingDistance)
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
        //playerHealth.TakeDamage(damage);
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