using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float stamina;
    private float maxStamina;
    public Slider staminabar;
    public float dValue;
    public float dValueRecargar;

    void Start()
    {
        maxStamina = stamina;
        staminabar.maxValue = maxStamina;
    }

    void Update()
    {
        //staminabar.value = stamina;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DecreaseEnergy();
            print("disminuye stamina");
        }
        IncreaseEnergy();

    }

    private void DecreaseEnergy()
    {
        if (stamina > 0)
        {
            stamina -= dValue * Time.deltaTime;
        }

        if (stamina <= 0)
        {
            stamina = 0;
        }
    }

    private void IncreaseEnergy()
    {
        stamina += dValueRecargar * Time.deltaTime;

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
    }
}



