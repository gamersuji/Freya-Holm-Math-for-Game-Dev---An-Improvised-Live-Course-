using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField]private Image healthBGImage,actualHealthImage;
    [SerializeField]private float resultWidth;
    public static Action<Sprite> changeTex;


    private void OnEnable()
    {
        changeTex += ChangeHealthTexture;
    }

    private void OnDisable()
    {
        changeTex -= ChangeHealthTexture;
    }

    void Update()
    {
        if(GameController.currentGameState == GameState.Edit)
        {
            healthBGImage.rectTransform.sizeDelta  = actualHealthImage.rectTransform.sizeDelta = new Vector2(SelectableUI.BarWidth,healthBGImage.rectTransform.sizeDelta.y);
        }
        else if(GameController.currentGameState == GameState.Play)
        {
            float healthPercent = PlayerHealth.CurrentPlayerHealth / SelectableUI.PlayerMaxHealth;

            float currentSpriteScale = resultWidth = healthBGImage.rectTransform.sizeDelta.x * healthPercent * SpritePerPixel();

            if (actualHealthImage.sprite.texture.width * currentSpriteScale > healthBGImage.rectTransform.sizeDelta.x) return;
            actualHealthImage.rectTransform.sizeDelta = new Vector2(actualHealthImage.sprite.texture.width * currentSpriteScale, actualHealthImage.rectTransform.sizeDelta.y);
        }
    }


    private float SpritePerPixel()
    {
        float data = 1f / actualHealthImage.sprite.texture.width;
        return data;
    }

    private void ChangeHealthTexture(Sprite sprite)
    {
        actualHealthImage.sprite = sprite;
    }
}
