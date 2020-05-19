using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { Play, Edit };

public class GameController : MonoBehaviour
{
    [SerializeField]public static GameState currentGameState = GameState.Edit;

    public static void PlayEditButtonClicked(Action callback)
    {
        if(currentGameState == GameState.Edit)
        {
            currentGameState = GameState.Play;
        }
        else if(currentGameState == GameState.Play)
        {
            currentGameState = GameState.Edit;
        }

        callback();
    }



}
