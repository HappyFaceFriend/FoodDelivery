using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    [SerializeField] int stage;
    [SerializeField] Image [] starImages;
    [SerializeField] Sprite filledStar;
    [SerializeField] Sprite emptyStar;
    // Start is called before the first frame update
    void OnEnable()
    {
            int star = PlayerPrefs.GetInt("GameScene " + stage.ToString(), 0);
            for(int i = 0; i<3; i++)
            {
                if (i < star)
                    starImages[i].sprite = filledStar;
                else
                    starImages[i].sprite = emptyStar;
            }
    }

}
