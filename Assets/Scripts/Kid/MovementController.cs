using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float _followSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _rotateSpeed;
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
}
