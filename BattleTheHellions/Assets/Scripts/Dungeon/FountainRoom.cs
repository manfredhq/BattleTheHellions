using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FountainRoom : ARooms
{
    public float multiplierExperience = 1;
    public int baseValue = 10;

    public Button useButton;
    public Button leaveButton;

    public RewardManager rewardManager;

    private void Start()
    {
        useButton.onClick.AddListener(OnUseButton);
        leaveButton.onClick.AddListener(OnLeaveButton);
        useButton.interactable = true;
    }
    public void OnUseButton()
    {
        rewardManager.EarnExperience((int)(baseValue * multiplierExperience));
        useButton.interactable = false;
    }

    public void OnLeaveButton()
    {
        DungeonManager.instance.currentRoomIndex++;
        GameManager.instance.loadScene(2);
    }
}
