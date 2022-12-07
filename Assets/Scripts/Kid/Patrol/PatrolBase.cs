using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PatrolBase : MonoBehaviour
{
    protected FieldOfView Fov;
    protected KidBehaviour Kid;
    protected MovementController MoveController;

    [SerializeField] float FOVIncrease = 2f;
    float originalFOV;
    public abstract string GetAnimName();
    protected void Awake()
    {
        Fov = GetComponent<FieldOfView>();
        Kid = GetComponent<KidBehaviour>();
        MoveController = GetComponent<MovementController>();
        originalFOV = Fov.ViewRadius;
    }
    public virtual void OnEnter() 
    {
    }
    public virtual void OnExit() 
    {
    }
    public abstract void Move();
    public bool IsPlayerInSight()
    {
        var collisions = Fov.GetTransformsInView();
        PlayerBehaviour target = null;
        foreach (Transform t in collisions)
        {
            target = t.GetComponent<PlayerBehaviour>();
            if (target != null)
                return true;
        }
        return false;
    }
    public void FollowPlayer()
    {
        Fov.ViewRadius = originalFOV * FOVIncrease;
        Kid.ChangeState(new KidStates.FollowState(Kid));
    }
    public void OnStopFollow()
    {
        Fov.ViewRadius = originalFOV;

    }
}
