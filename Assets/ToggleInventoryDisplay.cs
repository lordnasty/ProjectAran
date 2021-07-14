using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class ToggleInventoryDisplay : MonoBehaviour
{
    private InventoryDisplay InvDisplay;
    private Character Player;
    private CharacterHandleWeapon mainHandleWeapon;
    private CharacterHandleSecondaryWeapon HandleSecondaryWeapon;

    private void Awake()
    {
        InvDisplay = GetComponentInChildren<InventoryDisplay>();
        Player = LevelManager.Instance.Players[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Player.FindAbility<CharacterHandleWeapon>())
        // {
        //     mainHandleWeapon = Player.FindAbility<CharacterHandleWeapon>();
        // }
    }
}
