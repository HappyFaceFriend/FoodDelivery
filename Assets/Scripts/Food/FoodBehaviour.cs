using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ��� �ൿ�� ���� �ֽ��ϴ�.
public class FoodBehaviour : MonoBehaviour
{
	public Food data;
	public void OnCollideWithPlayer()
	{
		Destroy(this.gameObject);
	}
}
