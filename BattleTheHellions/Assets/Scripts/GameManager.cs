using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Button fightButton;
    // Start is called before the first frame update
    void Start()
    {
        fightButton.onClick.AddListener(OnFightButtonPressed);
    }

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

    // Update is called once per frame
    void Update()
    {
        if(fightButton == null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                fightButton = GameObject.Find("Fight").GetComponent<Button>();
                fightButton.onClick.AddListener(OnFightButtonPressed);
            }
        }
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
        
    }

    public void OnFightButtonPressed()
    {
        loadScene(2);
    }
}
