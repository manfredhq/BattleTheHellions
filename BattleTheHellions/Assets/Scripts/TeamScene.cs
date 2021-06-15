using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamScene : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();

    public Button mainMenuButton;

    private List<Vector3> oldHeroesPosition = new List<Vector3>();
    private List<Quaternion> oldHeroesRotation = new List<Quaternion>();

    private void Start()
    {
        for (int i = 0; i < Player.instance.heroes.Count; i++)
        {
            GameObject heroe = Player.instance.heroes[i];
            oldHeroesPosition.Add(heroe.transform.position);
            oldHeroesRotation.Add(heroe.transform.rotation);
            heroe.transform.position = spawnPoints[i].transform.position;
            heroe.transform.rotation = spawnPoints[i].transform.rotation;

            heroe.GetComponent<ALivings>().isClickable = true;
            var collider = heroe.AddComponent<BoxCollider>();
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
}
