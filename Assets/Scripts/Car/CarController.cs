using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] CarBehaviour carprefab;
    [SerializeField] Transform[] startpoint;
    [SerializeField] float updateTime = 0.0f;
    [SerializeField] float freq = 5.0f;

    void OnTriggerEnter(Collider other)
    {
        CarBehaviour car = other.GetComponent<CarBehaviour>();

        if (car != null)
        {
            car.OnCollideWithController();
        }
    }

    void CarSpawn()
    {
        CarBehaviour car = Instantiate(carprefab);
        int randompoint = Random.Range(0, 4);
        car.transform.position = startpoint[randompoint].position;
        if (randompoint == 1 || randompoint == 3)
        {
            car.checkpoint = -1;
            car.transform.rotation = Quaternion.Euler(car.transform.rotation.x, car.transform.rotation.y + 180, car.transform.rotation.z);
        }
    }

    void Update() // freq 시간마다 주문 생성 
    {

        if (updateTime > freq)
        {
            CarSpawn();
            updateTime = 0;
        }

        else
        {
            updateTime += Time.deltaTime;
        }
    }
}
