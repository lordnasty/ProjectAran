using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;



public class BeamAmmoSwitcher : MonoBehaviour
{

    [SerializeField] private MMMultipleObjectPooler BeamAmmo;

    [SerializeField] private EDamageType CurrentAmmoType;
    private CharacterHandleWeapon HandleWeapon;

    private int CurrentPoolIndex;
    // Start is called before the first frame update
    void Start()
    {
        HandleWeapon = GetComponent<CharacterHandleWeapon>();
        BeamAmmo = HandleWeapon.CurrentWeapon.GetComponent<MMMultipleObjectPooler>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (BeamAmmo)
        // {
        //     CurrentPoolIndex = BeamAmmo.GetCurrentIndex();
        // }

        CurrentAmmoType = BeamAmmo.Pool[CurrentPoolIndex].GameObjectToPool.GetComponent<DamageOnTouch>()
            .DamageTypeCaused;

        if (Input.GetButtonDown("Player1_Fly"))
        {
            SwitchAmmo();
        }
    }

    void SwitchAmmo()
    {
        switch (CurrentPoolIndex)
        {
            case 0:
            {
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = false;
                CurrentPoolIndex = 1;
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = true;
                break;
            }
            case 1:
            {
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = false;
                CurrentPoolIndex = 2;
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = true;
                break;
            }
            case 2:
            {
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = false;
                CurrentPoolIndex = 0;
                BeamAmmo.Pool[CurrentPoolIndex].Enabled = true;
                break;
            }
            // case 3:
            // {
            //     BeamAmmo.Pool[CurrentPoolIndex].Enabled = false;
            //     CurrentPoolIndex = 4;
            //     BeamAmmo.Pool[CurrentPoolIndex].Enabled = true;
            //     break;
            // }
            // case 4:
            //     BeamAmmo.Pool[CurrentPoolIndex].Enabled = false;
            //     CurrentPoolIndex = 0;
            //     BeamAmmo.Pool[CurrentPoolIndex].Enabled = true;
            //     break;
        }
    }
}
