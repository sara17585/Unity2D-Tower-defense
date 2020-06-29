using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 3;


    float health;
    TextMeshProUGUI healthText;
    // Start is called before the first frame update

    void Start()
    {
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();

    }

    //public int Health()
    //{
    //    return health;
    //}

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public bool HaveEnoughHealth(int amount)
    {
        return health >= amount;


    }

    public void SpendHealth(int spend)
    {

        health -= spend;
        UpdateDisplay();
    }
}
