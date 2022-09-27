using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] AttackController _attackController;
    [SerializeField] GameObject _hitEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        KidBehaviour kid = other.GetComponent<KidBehaviour>();
        if (kid != null)
        {
            kid.OnGetHitted(_attackController.StunDuration);
            Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);

            SoundManager.Instance.PlaySound(SoundManager.Instance.HitSound);
        }
    }

}
