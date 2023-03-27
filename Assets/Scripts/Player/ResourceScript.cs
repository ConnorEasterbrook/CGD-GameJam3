using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceScript : MonoBehaviour
{
    public int ammoAmount = 0;
    public int ammoMaxAmount = 200;
    public int woodAmount = 50;
    public int woodMaxAmount = 100;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _woodText;

    // Update is called once per frame
    void Update()
    {
        _ammoText.text = "Ammo: " + ammoAmount.ToString();
        _woodText.text = "Wood: " + woodAmount.ToString();
    }

    public void RemoveAmmo(int amount)
    {
        ammoAmount -= amount;
    }

    public void RemoveWood(int amount)
    {
        woodAmount -= amount;
    }
}
