using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private static float currentPlayerHealth;

    private static float PlayerMaxHealth { get => SelectableUI.PlayerMaxHealth; }
    public static float CurrentPlayerHealth { get => currentPlayerHealth; set => currentPlayerHealth = value; }

    private void OnEnable()
    {
        SelectableUI.Attack += OnRecievingAttack;
        SelectableUI.UsePotion += OnRecievingPotion;
    }
    private void OnDisable()
    {
        SelectableUI.Attack -= OnRecievingAttack;
        SelectableUI.UsePotion -= OnRecievingPotion;
    }

    void Start()
    {
    }

    void Update()
    {

        if(GameController.currentGameState == GameState.Edit) CurrentPlayerHealth = PlayerMaxHealth;

        if (CurrentPlayerHealth <= 0) CurrentPlayerHealth = 0;

        if(currentPlayerHealth > PlayerMaxHealth) currentPlayerHealth = PlayerMaxHealth;
    }


    private void OnRecievingAttack()
    {
        CurrentPlayerHealth -= SelectableUI.Power;
    }

    private void OnRecievingPotion()
    {
        CurrentPlayerHealth += SelectableUI.PotionPotence;
    }





}
