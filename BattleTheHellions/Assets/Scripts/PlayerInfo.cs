using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public TMP_Text usernameText;

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            usernameText.text = Player.instance.username;
    }
}
