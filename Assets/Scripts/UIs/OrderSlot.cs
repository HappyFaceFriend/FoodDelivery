using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class OrderSlot : MonoBehaviour
{
    [SerializeField] Image [] foodImages;
    [SerializeField] Image houseImage;
    [SerializeField] Slider timer;
    [SerializeField] Gradient timerGradient;

    Animator animator;
    Order order;
    public Order Order { get { return order; } }

    Image filler;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        filler = timer.fillRect.GetComponent<Image>();
    }
    public void SetOrder(Order order)
    {
        this.order = order;
        for(int i=0; i<foodImages.Length; i++)
        {
            if (i < order.Foodlist.Count)
            {
                foodImages[i].gameObject.SetActive(true);
                foodImages[i].sprite = order.Foodlist[i].Icon;
            }
            else
                foodImages[i].gameObject.SetActive(false);
        }

        timer.maxValue = order.timelimit;
        timer.value = order.timelimit;

        houseImage.sprite = order.destination.Icon;
    }
    public void Kill()
    {
        animator.SetTrigger("Destroy");
    }
    public void AnimEvent_Destroy()
    {
        Destroy(gameObject);
    }
    public void OnUpdate()
    {
        timer.value = order.timelimit;
        filler.color = timerGradient.Evaluate(1 - timer.normalizedValue);
    }
}
