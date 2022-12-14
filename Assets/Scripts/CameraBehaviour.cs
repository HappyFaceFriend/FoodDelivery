using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _followSpeed;

    public float FollowSpeed { get{ return _followSpeed; } set { _followSpeed = value; } }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _followSpeed * Time.deltaTime);

    }
}
