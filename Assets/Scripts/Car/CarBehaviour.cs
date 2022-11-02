using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    Vector3 position;
    [SerializeField] float _moveSpeed = 2;

    private void Start()
    {
        SetPosition();
    }

    private void Update()
    {
        MoveCar();
    }
    
    public void SetPosition()
    {
        position = transform.position;
    }

    public void MoveCar()
    {
        position.z += _moveSpeed * Time.deltaTime;

        transform.position = position;
    }

}
