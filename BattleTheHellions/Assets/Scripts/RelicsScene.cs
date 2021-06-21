using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RelicsScene : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonsParent;

    public GameObject relicsInformationPanel;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text effectDescriptionText;

    public Button relicsButton;
    public Button closePanel;

    public GameObject relicPanel;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var relic in Player.instance.inventory.relicsOwn)
        {
            var temp = Instantiate(buttonPrefab, buttonsParent.transform);
            temp.GetComponent<RelicsButton>().SetUp(relic,this);
        }
        relicsInformationPanel.SetActive(false);
        relicPanel.SetActive(false);
        relicsButton.onClick.AddListener(RelicPanelON);
        closePanel.onClick.AddListener(RelicPanelOFF);
    }

    public void RelicPanelON()
    {
        GetComponent<TeamScene>().mainUI.SetActive(false);
        relicPanel.SetActive(true);
        foreach (var heroe in Player.instance.heroes)
        {
            heroe.GetComponent<ALivings>().isClickable = false;
        }
    }

    public void RelicPanelOFF()
    {
        relicPanel.SetActive(false);
        relicsInformationPanel.SetActive(false);
        foreach (var heroe in Player.instance.heroes)
        {
            heroe.GetComponent<ALivings>().isClickable = true;
        }
    }

    public void RelicInformationON(ARelics r)
    {
        relicsInformationPanel.SetActive(true);
        nameText.text = r.name;
        descriptionText.text = r.description;
        effectDescriptionText.text = r.effectDescription;
    }

}
