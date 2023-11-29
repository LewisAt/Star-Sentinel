using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private OxygenTank oxygenTank;
    private float oxygenTankValue;

    private float sliderValue;

    private void Awake()
    {
        sliderValue = GetComponentInChildren<Slider>().value;
        oxygenTank = GameObject.FindGameObjectWithTag("Player").GetComponent<OxygenTank>();
        oxygenTankValue = oxygenTank.oxygenValue;
    }
    void Start()
    {
        print(oxygenTank);
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = oxygenTankValue;
        print(sliderValue);
    }

}
