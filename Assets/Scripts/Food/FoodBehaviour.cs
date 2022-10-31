using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 음식의 모든 행동은 여기 있습니다.
public class FoodBehaviour : MonoBehaviour
{
	public Food data;
	public void OnCollideWithPlayer()
	{
		Destroy(this.gameObject);
	}
}
