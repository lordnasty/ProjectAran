using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class AranObjectPooler : MMMultipleObjectPooler
{
    protected override void Awake()
    {
        base.Awake();
        PoolingMethod = MMPoolingMethods.OriginalOrderSequential;
    }
}
