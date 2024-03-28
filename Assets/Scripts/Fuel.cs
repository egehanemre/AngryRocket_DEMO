using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Text fuelText;
    void Update()
    {
        fuelText.text = "Fuel: " + Mathf.Round(Movement.currentFuel);
    }
}