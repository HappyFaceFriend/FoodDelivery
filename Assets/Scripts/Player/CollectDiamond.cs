using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDiamond : MonoBehaviour
{
    [SerializeField] LevelManager _levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Destroy(other.gameObject);
            _levelManager.OnCollectDiamond();
            SoundManager.Instance.PlaySound(SoundManager.Instance.GemSound);
        }
    }
}
