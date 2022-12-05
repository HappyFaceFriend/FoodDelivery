using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StayLookAroundPatrol : PatrolBase
{
    [SerializeField] float rotateAmount = 1;
    [SerializeField] float rotateSpeed = 180;
    [SerializeField] float rotation;
    [SerializeField] Transform head;

    bool doUpdate = false;
    float eTime = 0f;
    public override void OnEnter()
    {
        base.OnEnter();
        doUpdate = true;
        rotation = 0;
        eTime = 0f;
    }
    public override void OnExit()
    {
        base.OnExit();
        doUpdate = false;
    }
    public override void Move()
    {
    }
    public void LateUpdate()
    {
        if (!doUpdate)
            return;
        eTime += Time.deltaTime;
        rotation = Mathf.Sin(eTime * rotateSpeed * Mathf.Deg2Rad) * rotateAmount * Mathf.Rad2Deg;
        head.rotation = Quaternion.Euler(head.rotation.eulerAngles + new Vector3(0, rotation, 0));
        Fov.SetAdditionalRotation(rotation);
    }
    public override string GetAnimName()
    {
        return "Idle";
    }
}
