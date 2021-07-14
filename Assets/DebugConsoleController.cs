using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;
using Popcron.Console;

public class Commands
{
    // [Command("EnableAbility")]
    // public static void GrantAbility(CharacterAbility InAbility)
    // {
    //
    // }
}
// TODO: Create unlocker gameobjects and move them to Resources folder for Console and ease of access
public class DebugConsoleController : MonoBehaviour
{


    private void OnEnable()
    {
       Parser.Register(this, "Player");
    }

    private void OnDisable()
    {
        Parser.Unregister(this);
    }
}
