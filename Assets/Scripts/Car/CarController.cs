using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Destroy(other.gameObject);
            Debug.Log("´ê¾Ò½À´Ï´Ù");
        }
    }
}
