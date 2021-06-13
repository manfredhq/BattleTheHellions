using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    public TMP_Text usernameText;

    private void Update()
    {
        usernameText.text = Player.instance.username;
    }
}
