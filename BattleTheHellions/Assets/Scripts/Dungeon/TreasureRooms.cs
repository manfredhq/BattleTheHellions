using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureRooms : ARooms
{

    public float goldMultiplier = 1;

    public RewardManager rewardManager;

    public Button takeButton;
    public Button leaveButton;
    // Start is called before the first frame update
    private void Start()
    {
        takeButton.onClick.AddListener(OnTakeButton);
        leaveButton.onClick.AddListener(OnLeaveButton);
        takeButton.interactable = true;
    }

    public void OnTakeButton()
    {

        Player.instance.inventory.GetRelic(rewardManager.RandomRelic());
        rewardManager.RandomGold(goldMultiplier);
        takeButton.interactable = false;
    }

    public void OnLeaveButton()
    {
        DungeonManager.instance.currentRoomIndex++;
        GameManager.instance.loadScene(2);
    }
}
