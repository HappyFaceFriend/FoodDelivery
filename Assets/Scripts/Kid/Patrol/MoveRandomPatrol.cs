using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveRandomPatrol : PatrolBase
{
    [SerializeField] float runSpeed;
    [SerializeField] float waitTime;

    NavMeshAgent agent;
    float originalSpeed;

    [SerializeField] Transform target = null;

    float eTime = -1f;
    void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        originalSpeed = agent.speed;
        agent.speed = runSpeed;
        eTime = -1f;
        target = Kid.Group.GetRandomTargetPoint(target);
        MoveController.MoveTo(target.position);
    }
    public override void OnExit()
    {
        base.OnExit();
        agent.speed = originalSpeed;
    }
    public override void Move()
    {
        if(eTime < 0 && agent.remainingDistance < 0.01f)
        {
            MoveController.StopMove();
            Kid.Animator.SetTrigger("Idle");
            eTime = 0f;
        }
        if(eTime >= 0f)
        {
            eTime += Time.deltaTime;
            if(eTime >= waitTime)
            {
                target = Kid.Group.GetRandomTargetPoint(target);
                MoveController.MoveTo(target.position);
                Kid.Animator.SetTrigger("Patrol");
                eTime = -1f;
            }
        }

    }
    public override string GetAnimName()
    {
        return "Patrol";
    }
}
