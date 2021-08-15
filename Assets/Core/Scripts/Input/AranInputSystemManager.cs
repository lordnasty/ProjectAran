using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class AranInputSystemManager : InputSystemManager
{
  
    
    protected override void Initialization()
    {
        base.Initialization();
        InputActions.PlayerControls.AimDiagonal.performed += context => { BindButton(context, AimDiagonalButton); };
        InputActions.PlayerControls.Journal.performed += context => { BindButton(context, JournalButton); };

    }


   
}
