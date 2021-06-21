using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicsButton : MonoBehaviour
{
    public Button button;
    public ARelics relic;
    private RelicsScene relicScene;

    public void SetUp(ARelics r, RelicsScene rs)
    {
        relicScene = rs;
        relic = r;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        GetComponent<Image>().sprite = relic.sprite;
    }
    public void OnButtonClick()
    {
        relicScene.RelicInformationON(relic);
    }
}
