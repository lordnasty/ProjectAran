using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class PlayerSpeedBooster : MonoBehaviour
{
    
    protected MMStateMachine<CharacterStates.MovementStates> _movement;
    protected CharacterHorizontalMovement HorizontalMovement;
    [SerializeField] protected bool bIsBoosting = false;

    private Character _character;
    [SerializeField] private float LengthTillSpeedBooster = 12.0f;
    [SerializeField] private float CurrentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _character = this.gameObject.GetComponentInParent<Character>();
        HorizontalMovement = GetComponent<CharacterHorizontalMovement>();
        _movement = _character.MovementState;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((_movement.CurrentState == CharacterStates.MovementStates.Walking) || (_movement.CurrentState == CharacterStates.MovementStates.Running))
        {
            CurrentTime += 0.01f;
         //  Debug.Log(CurrentTime);
            if (CurrentTime >= LengthTillSpeedBooster)
            {
                bIsBoosting = true;
                HorizontalMovement.ModifyMovementSpeedModifier(2.00f);
                if (_movement.CurrentState != CharacterStates.MovementStates.Running)
                {
                    _movement.ChangeState(CharacterStates.MovementStates.Running);
                }
              
            }
        }
        else
        {
            bIsBoosting = false;
            
            CurrentTime -= 0.01f;
        }

        if (_movement.CurrentState == CharacterStates.MovementStates.Idle)
        {
            ResetBoostStatus();
        }

        if (CurrentTime <= 0.0f)
        {
            ResetBoostStatus();
        }
    }

    void ResetBoostStatus()
    {
        bIsBoosting = false;
        CurrentTime = 0.0f;
        HorizontalMovement.ResetHorizontalSpeed();
        _movement.ChangeState(CharacterStates.MovementStates.Walking);
    }
}
