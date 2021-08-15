using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class HealthUpgradePickup : MonoBehaviour
{
    private Character playerCharacter;
  

    private ID_HealthUpgradeCanvas _healthUpgradeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _healthUpgradeCanvas = FindObjectOfType<ID_HealthUpgradeCanvas>();
        _healthUpgradeCanvas.gameObject.SetActive(false);
   
    }

    private void Update()
    {
        if (!playerCharacter)
        {
            playerCharacter = LevelManager.Instance.Players[0];
        }
        
        if (Input.GetButtonDown("Player1_Jump"))
        {
            if (GameManager.Instance.Paused)
            {
                GameManager.Instance.UnPause();
                playerCharacter.FindAbility<CharacterPause>().UnPauseCharacter();
                _healthUpgradeCanvas.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() == playerCharacter)
        {
            playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().MaximumHealth =
                playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().InitialHealth + 100;
            playerCharacter.gameObject.MMGetComponentNoAlloc<Health>().ResetHealthToMaxHealth();
            playerCharacter.FindAbility<CharacterPause>().PauseCharacter();
            _healthUpgradeCanvas.gameObject.SetActive(true);
            GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
            
        }
        
    }
}
