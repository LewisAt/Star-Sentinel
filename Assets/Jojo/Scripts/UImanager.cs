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

    private Slider oxygenSlider;

    private TextMeshProUGUI currentHeightText;
    private float currentHeightNum;
    public static bool bossFight;


    private void Awake()
    {
        bossFight = false;
        oxygenSlider = GetComponentInChildren<Slider>();
        currentHeightText = GetComponentInChildren<TextMeshProUGUI>();
        oxygenTank = GameObject.FindGameObjectWithTag("Player").GetComponent<OxygenTank>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //updating oxygen
        oxygenTankValue = oxygenTank.oxygenValue;
        oxygenSlider.value = oxygenTankValue;

        //updating current height
        currentHeightNum = playerMovement.currentHeight;
        currentHeightText.text = string.Format("Current Height: {0}", currentHeightNum.ToString("0.00"));
    }
}
