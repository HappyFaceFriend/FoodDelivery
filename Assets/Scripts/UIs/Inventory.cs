using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Image iconSource;
    [SerializeField] Transform iconParent;

    List<Image> icons = new List<Image>();
    public void Add(Food food)
    {
        var icon = Instantiate(iconSource, iconParent);
        icon.sprite = food.Icon;
        icon.gameObject.SetActive(true);
        icons.Add(icon);
    }
    public void Remove(Food food)
    {
        for(int i=0; i<icons.Count; i++)
        {
            if(icons[i].sprite == food.Icon)
            {
                Destroy(icons[i].gameObject);
                icons.RemoveAt(i);
            }
        }
    }
}
