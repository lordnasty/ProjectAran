using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class UnlockDamageDash : MonoBehaviour
{
    public CharacterDamageDash DamageDash;
    // Start is called before the first frame update
    void Start()
    {
        DamageDash = GetComponentInParent<CharacterDamageDash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
