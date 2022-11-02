using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
	public Food data;
	public void OnCollideWithPlayer()
	{
		Destroy(this.gameObject);
	}

}
