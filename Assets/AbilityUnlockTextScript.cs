using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;

public class AbilityUnlockTextScript : MonoBehaviour
{
    private TextMeshProUGUI TextMesh;

    private void Awake()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
    }

    public TextMeshProUGUI GetTextComp()
    {
        return TextMesh;
    }


    

}
