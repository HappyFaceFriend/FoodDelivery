using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdersPanel : MonoBehaviour
{
    [SerializeField] OrderSlot orderSlotPrefab;

    List<OrderSlot> orderSlots = new List<OrderSlot>();
    public void AddOrderSlot(Order order)
    {
        OrderSlot slot = Instantiate(orderSlotPrefab, transform);
        slot.SetOrder(order);
        orderSlots.Add(slot);
    }

    public void RemoveOrderSlot(Order order)
    {
        OrderSlot slot = orderSlots.Find(x => x.Order == order);
        orderSlots.Remove(slot);
        slot.Kill();
    }
    private void Update()
    {
        foreach (OrderSlot slot in orderSlots)
            slot.OnUpdate();
    }
}
