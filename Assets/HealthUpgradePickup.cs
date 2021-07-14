using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class HealthUpgradePickup : MonoBehaviour
{
    private Character playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (!playerCharacter)
        {
            playerCharacter = LevelManager.Instance.Players[0];
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() == playerCharacter)
        {
            playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth =
                playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().InitialHealth + 100;
            playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().ResetHealthToMaxHealth();
            this.gameObject.SetActive(false);
        }
        //this.gameObject.SetActive(false);
    }
}
