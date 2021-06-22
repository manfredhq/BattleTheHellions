using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroeButton : MonoBehaviour
{
    public Button button;
    public GameObject heroeObj;
    public ALivings heroe;

    public void SetUp(ALivings h, GameObject hObj)
    {
        heroeObj = hObj;
        heroe = h;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        GetComponent<Image>().sprite = heroeObj.GetComponent<SpriteRenderer>().sprite;
    }
    public void OnButtonClick()
    {
        Debug.Log("Heroe pick");
    }
}
