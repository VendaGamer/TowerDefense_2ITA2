using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform currentWaypoint;
    [SerializeField] float speed;
    [SerializeField] float attackInterval=4f;
    float currentAttackInterval;

    Animator animator;
    private void Update()
    {
        var direction = currentWaypoint.position - transform.position;
        var movement = direction.normalized * speed * Time.deltaTime;

        currentAttackInterval -= Time.deltaTime;

        if (currentAttackInterval<=0)
        {
            animator.SetTrigger("Attack");
            currentAttackInterval = attackInterval;
        }



        if(movement.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetInteger("State",3);
        transform.Translate(movement);

        if (Vector3.Distance(currentWaypoint.position, transform.position) < 0.01f)
        {
            currentWaypoint = WaypointProvider.Instance.GetNextWaypoint(currentWaypoint);
            if (currentWaypoint == null)
            {
                //hp minus do base
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        currentWaypoint = WaypointProvider.Instance.GetNextWaypoint();
        animator = GetComponentInChildren<Animator>();
    }
}
