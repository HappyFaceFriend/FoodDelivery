using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PatrolBase : MonoBehaviour
{
    protected FieldOfView Fov;
    protected KidBehaviour Kid;
    protected MovementController MoveController;
    private void Awake()
    {
        Fov = GetComponent<FieldOfView>();
        Kid = GetComponent<KidBehaviour>();
        MoveController = GetComponent<MovementController>();
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
        Kid.ChangeState(new KidStates.FollowState(Kid));
    }
}
