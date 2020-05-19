using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    [SerializeField]private GameState overlayType = GameState.Edit;
    private Image overlayImage;


    private void Awake()
    {
        overlayImage = GetComponent<Image>();
    }


    public void SetOverlayType()
    {
        if (GameController.currentGameState == overlayType) overlayImage.enabled = false;
        else overlayImage.enabled = true;
    }

}
