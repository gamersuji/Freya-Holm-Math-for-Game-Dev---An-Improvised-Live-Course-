using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableUI : MonoBehaviour
{
    [Range(1, 1000)]
    private static int playerMaxHealth;
    [Range(1, 235)]
    private static int barWidth;
    [Range(1, 500)]
    private static int power;

    [Range(1, 500)]
    private static int potionPotence;

    private int basicValue = 10;

    [SerializeField] private Text showMaxHealth;
    [SerializeField] private Text showbarWidth;
    [SerializeField] private Text showPower;




    public static Action Attack;
    public static Action UsePotion;

    public static int PlayerMaxHealth
    {
        get => playerMaxHealth;
        private set
        {
            playerMaxHealth = CurbValues(1, 1000, value);
        }
    }

    public static int BarWidth
    {
        get => barWidth;
        private set
        {
            barWidth = CurbValues(1, 235, value);
        }
    }

    public static int Power
    {
        get => power;
        private set
        {
            power = CurbValues(1, 500, value); 
        }
    }
    public static int PotionPotence {
        get => potionPotence;
        private set
        {
            potionPotence = CurbValues(1, 500, value);
        }
    }

    private void Start()
    {
        PlayerMaxHealth = 1000/2;
        BarWidth = 235/2;
        Power = 500/2;
        PotionPotence = 500 / 2;

        SetAllOverlays();
    }

    private void Update()
    {
        showMaxHealth.text = PlayerMaxHealth.ToString();
        showbarWidth.text = BarWidth.ToString();
        showPower.text = Power.ToString();

    }

    public void ClickAttack() { Attack(); }

    public void ClickPotion() { UsePotion(); }


    public void IncreaseMaxHealth() { PlayerMaxHealth += basicValue; }

    public void DecreaseMaxHealth() { PlayerMaxHealth -= basicValue; }

    public void IncreaseBarWidth() { BarWidth += basicValue; }

    public void DecreaseBaWidth() { BarWidth -= basicValue; }

    public void IncreasePower() { Power += basicValue; }

    public void DecreasePower() { Power -= basicValue; }

    public void IncreasePotionPotence() { PotionPotence += basicValue; }

    public void DecreasePotionPotence() { PotionPotence -= basicValue; }


    private static int CurbValues(int min, int max, int value)
    {
        int result = min;

        if (value < min) result = min;

        else if (value > max) result = max;

        else result = value;

        return result;

    }


    public void PlayEditButtonClicked()
    {
        GameController.PlayEditButtonClicked(()=> { SetAllOverlays(); });
    }

    private void SetAllOverlays()
    {
        Overlay[] overlays = FindObjectsOfType<Overlay>();

        foreach (var overlay in overlays)
        {
            overlay.SetOverlayType();
        }
    }



}
