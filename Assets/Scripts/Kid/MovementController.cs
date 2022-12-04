using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    [SerializeField] float _followSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;

    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveAndRotateTowards(Vector3 position, float epsilon, bool isFollow = false)
    {
        Vector3 moveDir = position - transform.position;
        float size = moveDir.magnitude;
        moveDir /= size;
        if (size > epsilon)
        {
            if (isFollow)
                transform.Translate(moveDir * _followSpeed * Time.deltaTime, Space.World);
            else
                transform.Translate(moveDir * _moveSpeed * Time.deltaTime, Space.World);
        }

        if (moveDir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
        }

    }
    public void RotateTowards(Quaternion targetRotation)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
        
    }
    public bool HasArrived()
    {
        return agent.remainingDistance < 0.01;
    }
    public void MoveTo(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
        
        agent.isStopped = false;
    }
    public void StopMove()
    {
        agent.isStopped = true;
    }
}
