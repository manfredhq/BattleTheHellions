using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour
{
    public int currentRoomIndex = 0;

    public GameObject selectDifficultyUI;

    public GameObject nextRoomUI;
    public Button nextRoomButton;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button insaneButton;

    public static DungeonManager instance;

    public TreasureRooms treasureRoom;

    public List<roomTypes> easyDungeon = new List<roomTypes>();

    public List<roomTypes> mediumDungeon = new List<roomTypes>();

    public List<roomTypes> hardDungeon = new List<roomTypes>();

    public List<roomTypes> insaneDungeon = new List<roomTypes>();

    public List<FightRooms> easyFightRooms = new List<FightRooms>();

    public List<FightRooms> mediumFightRooms = new List<FightRooms>();

    public List<FightRooms> hardFightRooms = new List<FightRooms>();

    public List<FightRooms> insaneFightRooms = new List<FightRooms>();

    public List<ARooms> currentRun = new List<ARooms>();
    private int selectedDifficulty = 0;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    private void Update()
    {
        if (easyButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                easyButton = GameObject.Find("Easy").GetComponent<Button>();
                easyButton.onClick.AddListener(GenerateEasy);
            }
        }
        if (mediumButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                mediumButton = GameObject.Find("Medium").GetComponent<Button>();
                mediumButton.onClick.AddListener(GenerateMedium);
            }
        }
        if (hardButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                hardButton = GameObject.Find("Hard").GetComponent<Button>();
                hardButton.onClick.AddListener(GenerateHard);
            }
        }
        if (insaneButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                insaneButton = GameObject.Find("Insane").GetComponent<Button>();
                insaneButton.onClick.AddListener(GenerateInsane);
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            selectDifficultyUI = GameObject.Find("DifficultyUI");
            if (nextRoomUI == null)
            {

                nextRoomUI = GameObject.Find("NextRoomUI");
            }
            if(nextRoomButton == null)
            {
                nextRoomButton = nextRoomUI.GetComponent<Button>();
                nextRoomButton.onClick.AddListener(NextRoom);
            }
        }

        if(currentRoomIndex == 0 && selectDifficultyUI!=null && nextRoomUI!= null)
        {
            selectDifficultyUI.SetActive(true);
            nextRoomUI.SetActive(false);
        }
        else if(selectDifficultyUI != null && nextRoomUI != null)
        {
            selectDifficultyUI.SetActive(false);
            nextRoomUI.SetActive(true);
        }
    }
    void GenerateEasy()
    {
        for (int i = 0; i < easyDungeon.Count; i++)
        {
            if(easyDungeon[i] == roomTypes.fight)
            {
                var roomIndex = Random.Range(0, easyFightRooms.Count);
                currentRun.Add(easyFightRooms[roomIndex]);
            }
            else if (easyDungeon[i] == roomTypes.fountain)
            {
                currentRun.Add(null);
            }
            else if (easyDungeon[i] == roomTypes.treasure)
            {

            }
        }
        selectedDifficulty = 1;
        NextRoom();
    }

    void GenerateMedium()
    {

        selectedDifficulty = 2;
    }

    void GenerateHard()
    {
        selectedDifficulty = 3;

    }

    void GenerateInsane()
    {

        selectedDifficulty = 4;
    }

    public void NextRoom()
    {
        Debug.Log("tata");
        List<roomTypes> rooms = new List<roomTypes>();
        if(selectedDifficulty == 1)
        {
            rooms = easyDungeon;
        }
        else if(selectedDifficulty == 2)
        {
            rooms = mediumDungeon;
        }
        else if (selectedDifficulty == 3)
        {
            rooms = hardDungeon;
        }
        else if (selectedDifficulty == 4)
        {
            rooms = insaneDungeon;
        }

        if (rooms[currentRoomIndex] == roomTypes.fight)
        {
            GameManager.instance.loadScene(1);
        }
        else if (rooms[currentRoomIndex] == roomTypes.fountain)
        {
            GameManager.instance.loadScene(3);
        }
        else if (rooms[currentRoomIndex] == roomTypes.treasure)
        {

        }
    }
}


public enum roomTypes
{
    fight,
    fountain,
    treasure
}