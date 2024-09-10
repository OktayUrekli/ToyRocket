using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] Image fuelBar;
    [SerializeField] GameObject fuelOverPanel;

    float fuelAmount = 100;

    public float FuelAmount { get { return fuelAmount; } set { fuelAmount =value; } }

    void Start()
    {
        fuelOverPanel.SetActive(false);
    }

    public void UpdateFuelBar()
    {
        if (fuelAmount <= 100 && fuelAmount > 0)
        {
            fuelBar.fillAmount = FuelAmount / 100f;
        }
        else if (fuelAmount > 100)
        {
            fuelAmount = 100;
            fuelBar.fillAmount = FuelAmount / 100f;
        }
        else if (fuelAmount <= 0)
        {
            Time.timeScale = 0;
            fuelOverPanel.SetActive(true);
        }
    }

}
