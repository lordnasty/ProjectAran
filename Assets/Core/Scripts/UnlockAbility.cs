using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;



public class UnlockAbility : MonoBehaviour, MMEventListener<PAAbilityUnlockedEvent>
{
    public CharacterAbility AbilityToEnable;

    [SerializeField] private GameObject Player;
    private Character _character;
    public int AbilityToModifyIndexLocation = 0;
    private ID_AbilityUnlockCanvas AbilityUnlockCanvas;

    [SerializeField] CharacterAbility[] currentAbilities;

    // Start is called before the first frame update
    void Start()
    {
        AbilityUnlockCanvas = FindObjectOfType<ID_AbilityUnlockCanvas>();
        AbilityUnlockCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            currentAbilities = Player.GetComponents<CharacterAbility>();
            _character = Player.GetComponent<Character>();
        }

        if (!AbilityToEnable)
        {
            AbilityToEnable = currentAbilities[AbilityToModifyIndexLocation];
            Debug.Log(AbilityToEnable.AbilityName);
        }

        if (Input.GetButtonDown("Player1_Jump"))
        {
            if (GameManager.Instance.Paused)
            {
                GameManager.Instance.UnPause();
                Player.GetComponent<CharacterPause>().UnPauseCharacter();
                AbilityUnlockCanvas.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.gameObject == Player)
        {
            for (int i = 0; i < currentAbilities.Length; i++)
            {
                if (currentAbilities[i] == AbilityToEnable)
                {
                    _character.GetCharacterAbilities()[AbilityToModifyIndexLocation].PermitAbility(true);

                    MMGameEvent.Trigger("Save");
                    MMEventManager.TriggerEvent(new PAAbilityUnlockedEvent(AbilityToEnable.AbilityName + "!"));
                    Player.GetComponent<CharacterPause>().PauseCharacter();
                    GameManager.Instance.Pause(PauseMethods.NoPauseMenu);
                    
                }
                // else
                // {
                //     if (currentAbilities[i].AbilityPermitted)
                //     {
                //         Player.GetComponent<CharacterAbility>().AbilityPermitted = true;
                //     }
                // }
            }
        }
    }

    void OnEnable()
    {
        this.MMEventStartListening<PAAbilityUnlockedEvent>();
    }

    void OnDisable()
    {
        this.MMEventStopListening<PAAbilityUnlockedEvent>();
    }

    public void OnMMEvent(PAAbilityUnlockedEvent eventType)
    {
        AbilityUnlockTextScript textScript =
            AbilityUnlockCanvas.GetComponentInChildren<AbilityUnlockTextScript>();
        textScript.GetTextComp().text =
            eventType.AbilityName;
        AbilityUnlockCanvas.gameObject.SetActive(true);
    }
}

//TODO: Create event that will show a UI Message after picking up a new ability/weapon