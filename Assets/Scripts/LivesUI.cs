using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;

    public LocalizeStringEvent stringEvent;

    void Update()
    {
        livesText.text = PlayerStats.Lives + " LIVES";
        stringEvent.RefreshString();
    }
}
