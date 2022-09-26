using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidStates
{
    public class PatrolState : KidState
    {
        MovementController _movementController;
        FieldOfView _fov;
        float _eTime = 0f;
        float _checkInterval = 0.1f;
        public PatrolState(KidBehaviour kid) : base("Patrol", kid)
        {
            _movementController = Kid.GetComponent<MovementController>();
            _fov = Kid.GetComponent<FieldOfView>();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            Vector3 nextPosition = transform.position + transform.forward
                + transform.right * Mathf.Tan(Kid.PatrolAngle * Mathf.Deg2Rad);    
            _movementController.MoveAndRotateTowards(nextPosition, 0.05f);

            _eTime += Time.deltaTime;
            if (_eTime >= _checkInterval)
            {
                _eTime -= _checkInterval;
                var collisions = _fov.GetTransformsInView();
                PlayerBehaviour target = null;
                foreach (Transform t in collisions)
                {
                    target = t.GetComponent<PlayerBehaviour>();
                    if (target != null)
                        break;
                }
                if (target != null)
                {
                    Kid.ChangeState(new FollowState(Kid));
                }
            }
        }
    }
}
