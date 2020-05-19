using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SetTexture : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnTextureClick);
    }

    private void OnTextureClick()
    {
        HealthBarUI.changeTex(GetComponent<Image>().sprite);
    }


}
