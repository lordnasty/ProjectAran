using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using TMPro;
using UnityEngine;

public class SubweaponAmmoDisplay : MonoBehaviour
{
    public TextMeshProUGUI AmmoTextComp;

    private GameObject playerGO;
    //This is the ammo type we're looking for, to assign each instance to each weapon
    public string DesiredAmmoID;

    private CharacterHandleSecondaryWeapon SubweaponHandler;

    private WeaponAmmo _weaponAmmo;
    // Start is called before the first frame update
    
    void Start()
    {
       
        playerGO = GameObject.FindGameObjectWithTag("Player");
        AmmoTextComp = GetComponent<TextMeshProUGUI>();
        SubweaponHandler = playerGO.GetComponent<CharacterHandleSecondaryWeapon>();
    }

    private void LateUpdate()
    {
        if (!playerGO)
        {
            playerGO = GameObject.FindGameObjectWithTag("Player");
            SubweaponHandler = playerGO.GetComponent<CharacterHandleSecondaryWeapon>();
        }

        
        if (SubweaponHandler)
        {
            if (SubweaponHandler.CurrentWeapon)
            {
                _weaponAmmo = SubweaponHandler.CurrentWeapon.GetComponent<WeaponAmmo>();
                
                if (_weaponAmmo.AmmoID == DesiredAmmoID)
                {
                    AmmoTextComp.enabled = true;
                    if (SubweaponHandler.CurrentWeapon.MagazineBased)
                    {
                        AmmoTextComp.SetText(SubweaponHandler.CurrentWeapon.CurrentAmmoLoaded.ToString());
                    }
                }
                else
                {
                    AmmoTextComp.enabled = false;
                }
               
            }
          
        }
       
    }
}
