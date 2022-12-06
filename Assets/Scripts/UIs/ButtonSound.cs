using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler
{
    Button button;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlayButtonSound();
    }

    private void Awake()
    {
        button = GetComponent<Button>();
    }


}
