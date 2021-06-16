using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamScene : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();

    public Button mainMenuButton;

    public GameObject mainUI;
    public TMP_Text nameText;
    public TMP_Text levelText;
    public TMP_Text experienceText;
    public TMP_Text HPText;
    public TMP_Text attackText;
    public TMP_Text NOAText;
    public TMP_Text MTCText;
    public TMP_Text LifeStealText;

    private List<Vector3> oldHeroesPosition = new List<Vector3>();
    private List<Quaternion> oldHeroesRotation = new List<Quaternion>();

    private void Start()
    {
        mainUI.SetActive(false);
        GameManager.instance.SetHeroesVisible();
        for (int i = 0; i < Player.instance.heroes.Count; i++)
        {
            GameObject heroe = Player.instance.heroes[i];
            oldHeroesPosition.Add(heroe.transform.position);
            oldHeroesRotation.Add(heroe.transform.rotation);
            heroe.transform.position = spawnPoints[i].transform.position;
            heroe.transform.rotation = spawnPoints[i].transform.rotation;

            heroe.GetComponent<ALivings>().isClickable = true;
            heroe.AddComponent<BoxCollider>();
        }
    }

    public void onHeroeClicked(GameObject Heroe, int indexTest)
    {
        Debug.Log(indexTest);
    }
    public void OnMainMenuClicked()
    {
        for (int i = 0; i < Player.instance.heroes.Count; i++)
        {
            var heroe = Player.instance.heroes[i];
            heroe.transform.position = oldHeroesPosition[i];
            heroe.transform.rotation = oldHeroesRotation[i];
            heroe.GetComponent<ALivings>().isClickable = false;
            Destroy(heroe.GetComponent<BoxCollider>());
        }
        GameManager.instance.loadScene(0);
    }

    public void ShowInfo(ALivings heroe)
    {
        mainUI.SetActive(true);
        nameText.text = heroe.name;
        levelText.text ="level: "+ heroe.level.ToString();
        experienceText.text = "Experience: " + heroe.currentExperience.ToString() + " / " + heroe.level*heroe.level;
        HPText.text = "HP: " + heroe.maxHp.ToString();
        attackText.text = "Attack: " + heroe.maxAttack.ToString();
        NOAText.text = "Number of hit: " + heroe.numberOfHit.ToString();
        MTCText.text = "Mana: " + heroe.manaToCast.ToString();
        LifeStealText.text = "Lifesteal: " + heroe.lifeStealPercentage.ToString()+"%";
    }
}
