using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class CharacterAimDiagonal : CharacterAbility
{
    /// <summary>
    /// Add this class to a character so it can aim diagonally
    /// Note that this component will trigger animations (if their parameter is present in the Animator), based on 
    /// the current weapon's Animations
    /// Animator parameters : defined from the Weapon's inspector
    /// </summary>
    [AddComponentMenu("Project Aran/Character/Abilities/Character Aim Diagonal")]
    
    [Header("Weapons")]
    public CharacterHandleWeapon PrimaryWeapon;

    public WeaponAim currentPrimaryAimComp;
    public WeaponAim currentSecondaryAimComp;
    public CharacterHandleSecondaryWeapon SecondaryWeapon;
    private AranInputSystemManager _inputSystemManager;
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        print("Hi Mom!");
    }

 
    
    // Initialization
    protected override void Initialization()
    {
        base.Initialization();
        Setup();
    }
    
    /// <summary>
    /// Grabs various components and inits stuff
    /// </summary>

    public virtual void Setup()
    {
        _inputSystemManager = FindObjectOfType<AranInputSystemManager>();
        PrimaryWeapon = GetComponent<CharacterHandleWeapon>();
        currentPrimaryAimComp = PrimaryWeapon.CurrentWeapon.gameObject.GetComponent<WeaponAim>();
        SecondaryWeapon = GetComponent<CharacterHandleSecondaryWeapon>();
        if (SecondaryWeapon.CurrentWeapon)
        {
            currentSecondaryAimComp = SecondaryWeapon.CurrentWeapon.gameObject.GetComponent<WeaponAim>();    
        }
        
    }

    protected override void HandleInput()
    {
        //print(_inputSystemManager.AimDiagonalButton.State.CurrentState);
        if (_inputSystemManager.AimDiagonalButton.State.CurrentState == MMInput.ButtonStates.ButtonPressed)
        {
            AimWeaponStart();
        }
     

        if (_inputSystemManager.AimDiagonalButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
        {
            //print("I'm up!");
            //Reset weapon rotation
            AimWeaponStop();
        }
    }
    
    //TODO: Get player current Y rotation so that the model position remains consistent
    void AimWeaponStart()
    {
        if (PrimaryWeapon.CurrentWeapon)
        {
            if (!currentPrimaryAimComp)
            {
                currentPrimaryAimComp = PrimaryWeapon.CurrentWeapon.gameObject.GetComponent<WeaponAim>();    
            }
            
            currentPrimaryAimComp.AimControl = WeaponAim.AimControls.Script;
            if (PrimaryWeapon.CurrentWeapon.Owner.IsFacingRight)
            {
                currentPrimaryAimComp.SetCurrentAim(new Vector3(0.1f,0.1f,0.0f));    
            }
            else
            {
                currentPrimaryAimComp.SetCurrentAim(new Vector3(-0.1f,0.1f,0.0f));
            }
            
        }

        if (SecondaryWeapon.CurrentWeapon)
        {
            if (!currentSecondaryAimComp)
            {
                currentSecondaryAimComp = SecondaryWeapon.CurrentWeapon.gameObject.GetComponent<WeaponAim>();    
            }
            
            currentSecondaryAimComp.AimControl = WeaponAim.AimControls.Script;
            if (SecondaryWeapon.CurrentWeapon.Owner.IsFacingRight)
            {
                currentSecondaryAimComp.SetCurrentAim(new Vector3(0.1f,0.1f,0.0f));    
            }
            else
            {
                currentSecondaryAimComp.SetCurrentAim(new Vector3(-0.1f,0.1f,0.0f));
            }

        }
    }

    void AimWeaponStop()
    {
        if (PrimaryWeapon.CurrentWeapon)
        {
            currentPrimaryAimComp.AimControl = WeaponAim.AimControls.PrimaryMovement;
            currentPrimaryAimComp.SetCurrentAim(new Vector3(0.0f,0.0f,0.0f));
        }

        if (SecondaryWeapon.CurrentWeapon)
        {
            currentSecondaryAimComp.AimControl = WeaponAim.AimControls.PrimaryMovement;
            currentSecondaryAimComp.SetCurrentAim(new Vector3(0.0f,0.0f,0.0f));
        }
    }

    
}
