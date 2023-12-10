using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private OxygenTank oxygenTank;
    private PlayerController playerMovement;
    private float oxygenTankValue;

    private BossHealth boss;
    private Slider oxygenSlider;
    private Slider bossSlider;
    private float bossHealth;

    private TextMeshProUGUI currentHeightText;
    private float currentHeightNum;
    public static bool bossFight;


    private void Awake()
    {
        bossFight = false;

        oxygenSlider = transform.GetChild(0).GetComponent<Slider>();
        print(oxygenSlider.name);

        bossSlider = transform.GetChild(1).GetComponent<Slider>();
        print(bossSlider.name);

        currentHeightText = GetComponentInChildren<TextMeshProUGUI>();
        oxygenTank = GameObject.FindGameObjectWithTag("Player").GetComponent<OxygenTank>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
    }

    void Update()
    {
        //updating oxygen
        oxygenTankValue = oxygenTank.oxygenValue;
        oxygenSlider.value = oxygenTankValue;

        //updating boss health
        bossHealth = boss.health;
        bossSlider.value = bossHealth;

        //updating current height
        currentHeightNum = playerMovement.currentHeight;
        if (currentHeightText != null && currentHeightText.name != "BossName")
        {
            currentHeightText.text = string.Format("Current Height: {0}", currentHeightNum.ToString("0.00"));
        }
    }
}
