using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
	public House data;
	public void OnCollideWithPlayer()
	{
		
	}

	public House getHouse()
    {
		return this.data;
    }
}
