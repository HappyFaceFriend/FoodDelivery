using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCirclePatrol : PatrolBase
{
    [SerializeField] float patrolAngle;
    float _eTime = 0f;
    float _checkInterval = 0.1f;
    public override void Move()
    {
        _eTime += Time.deltaTime;
        if (_eTime >= _checkInterval)
        {
            _eTime -= _checkInterval;
            Vector3 nextPosition = transform.position + transform.forward
                + transform.right * Mathf.Tan(patrolAngle * Mathf.Deg2Rad);
            MoveController.MoveTo(nextPosition);
        }
    }
}
