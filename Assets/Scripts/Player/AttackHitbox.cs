using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] AttackController _attackController;
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        KidBehaviour kid = other.GetComponent<KidBehaviour>();
        if (kid != null)
        {
            kid.OnGetHitted(_attackController.StunDuration);
        }
    }
}
