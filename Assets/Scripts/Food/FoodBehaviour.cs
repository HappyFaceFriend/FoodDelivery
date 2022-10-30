using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public enum FoodType
    {
        Soda,
        Pizza,
        Cake,
        Hotdog,
        Lolipop
    }
    public FoodType type;
    private PlayerBehaviour _player;
    private GameObject[] _kids;

    public PlayerBehaviour Player
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
            return _player;
        }
    }

    public void Awake()
    {
        _kids = GameObject.FindGameObjectsWithTag("Kid");
    }

    private void OnCollisionStay(Collision collision)
    {
        OnCollision(collision);
    }

    private void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            // Scene�� ��� ���� �� ������ Player, Kid OnGameClear ó��
            if (GetFoodCount() == 0)
            {
                Player.OnGameClear();
                KidBehaviour[] kidBehaviour = new KidBehaviour[_kids.Length];
                for (int i = 0; i < kidBehaviour.Length; i++)
                {
                    kidBehaviour[i] = _kids[i].GetComponent<KidBehaviour>();
                    kidBehaviour[i].OnGameClear();
                }
                    
            }
                
        }
    }
    

    // ���� ���� ���ϱ�
    private int GetFoodCount()
    {
        return GameObject.FindGameObjectsWithTag("Food").Length - 1;
    }
   

}
