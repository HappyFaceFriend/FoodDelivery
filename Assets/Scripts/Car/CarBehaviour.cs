using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    Vector3 position;
    Vector3 startpoint = new Vector3(6.3f, -6.2f, -14.51f);
    public int checkpoint = 1;
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
        position.z += _moveSpeed * Time.deltaTime * checkpoint;

        transform.position = position;
    }

    public void OnCollideWithController()
    {
        Debug.Log("충돌했습니다");
        Destroy(this.gameObject);
    }

    public void OnCollideWithPlayer()
    {
       
    }

}
