using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsManager : MonoBehaviour
{
    public static BuildingsManager instance;

    public List<GameObject> buildingListObj = new List<GameObject>();
    private List<ABuilding> buildingList = new List<ABuilding>();

    private List<GameObject> buildingsOwnObj = new List<GameObject>();
    public List<ABuilding> buildingsOwn = new List<ABuilding>();

    private Button cartButton;
    public GameObject cartUI;
    public GameObject cartHeroeContainer;
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        cartUI.SetActive(false);
        for (int i = 0; i < buildingListObj.Count; i++)
        {
            buildingList.Add(buildingListObj[i].GetComponent<ABuilding>());
            buildingList[i].id = i;
            if (buildingList[i].isBuild) {
                buildingsOwnObj.Add(buildingListObj[i]);
                buildingsOwn.Add(buildingList[i]);
            }
        }
    }

    private void Update()
    {
        if(GameManager.instance.GetCurrentScene() == 0)
        {
            if (!cartButton) { 
                cartButton = GameObject.Find("Cart").GetComponent<Button>();
                cartButton.onClick.AddListener(OnCartClicked);
            }
            if(!cartUI)
                cartUI = GameObject.Find("CartUI");
        }
    }

    public void OnCartClicked()
    {
        var cart = buildingsOwn.Find(c => c.name == "Heroes Cart");
        cart.Effect();
        var heroesCart = cart.GetComponent<HeroesCart>();
        cartUI.SetActive(true);
        foreach (GameObject heroe in heroesCart.heroes)
        {
            GameObject h = Instantiate(heroesCart.heroesButtonPrefab, cartHeroeContainer.transform);
            h.GetComponent<HeroeButton>().SetUp(heroe.GetComponent<ALivings>(),heroe);
            heroesCart.heroesInstance.Add(h);
        }
    }

    public void OnCartClosed()
    {
        var cart = buildingsOwn.Find(c => c.name == "Heroes Cart");
        cart.UndoEffect();
    }
}
