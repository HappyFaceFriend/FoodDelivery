using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObject : MonoBehaviour
{
    public Vector3 OriginalPos { get; private set; }
    public Vector3 GoBackVector { get; set; }
    private void Awake()
    {
        OriginalPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "TitleWall")
        {
            transform.position += GoBackVector;
        }
    }
}
