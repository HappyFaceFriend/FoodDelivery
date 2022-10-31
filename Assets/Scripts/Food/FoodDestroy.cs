using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
	void OnTriggerEnter(Collider other)

	{
		if (other.gameObject.tag == "Player")

		{
			Destroy(this.gameObject);
			Debug.Log("사라졌습니다");
		}

	}

  
}
