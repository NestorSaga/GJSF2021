using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    PlayerController p1;
    Player_2_Controller p2;


    public Image knightSlider, bossSlider;

    void Start()
    {
        p1 = GameManager.Instance.p1;
        p2 = GameManager.Instance.p2;
    }

    // Update is called once per frame
    void Update()
    {
        knightSlider.fillAmount = p1.P1HP/p1.maxP1HP;
        bossSlider.fillAmount = p2.P2HP/p2.maxP2HP;
    }


}
