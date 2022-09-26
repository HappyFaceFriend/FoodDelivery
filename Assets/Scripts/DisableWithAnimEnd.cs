using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWithAnimEnd : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        {
            gameObject.SetActive(false);
        }

    }
}
