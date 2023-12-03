using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private OxygenTank oxygenTank;
    private float oxygenTankValue;

    private Slider oxygenSlider;
    private float sliderValue;

    private void Awake()
    {
        oxygenSlider = GetComponentInChildren<Slider>();
        oxygenTank = GameObject.FindGameObjectWithTag("Player").GetComponent<OxygenTank>();
    }

    void Update()
    {
        oxygenTankValue = oxygenTank.oxygenValue;
        oxygenSlider.value = oxygenTankValue;
    }
}
