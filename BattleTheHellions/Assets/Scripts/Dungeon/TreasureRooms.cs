using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureRooms : ARooms
{

    public float goldMultiplier = 1;

    public RewardManager rewardManager;

    public Button takeButton;
    public Button leaveButton;

    public TMP_Text rewardText;
    public Image rewardImage;
    public GameObject rewardPanel;
    // Start is called before the first frame update
    private void Start()
    {
        rewardPanel.SetActive(false);
        takeButton.onClick.AddListener(OnTakeButton);
        leaveButton.onClick.AddListener(OnLeaveButton);
        takeButton.interactable = true;
    }

    public void OnTakeButton()
    {
        rewardPanel.SetActive(true);
        ARelics relic = rewardManager.RandomRelic();
        if (relic != null)
        {
            rewardText.text = relic.name;
            rewardImage.sprite = relic.sprite;
            Player.instance.inventory.GetRelic(relic);
            rewardManager.RandomGold(goldMultiplier);
            takeButton.interactable = false;
        }
        else
        {
            rewardText.text = "No relic found";
        }
        
    }

    public void OnLeaveButton()
    {
        DungeonManager.instance.currentRoomIndex++;
        GameManager.instance.loadScene(2);
    }
}
