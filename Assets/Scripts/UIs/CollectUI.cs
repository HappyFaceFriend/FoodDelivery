using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CollectUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _currentText;
    [SerializeField] TextMeshProUGUI _maxText;

    public void Init(int max)
    {
        _currentText.text = "0";
        _maxText.text = "/ " + max.ToString();
    }
    public void SetCurrentCount(int count)
    {
        _currentText.text = count.ToString();
    }
}
