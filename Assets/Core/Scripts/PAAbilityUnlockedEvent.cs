using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PAAbilityUnlockedEvent
{
    public string AbilityName;

    public PAAbilityUnlockedEvent(string abilityName)
    {
        AbilityName = abilityName;
    }

    private static PAAbilityUnlockedEvent _event;

    public static void Trigger(string newAbilityUnlockedName)
    {
        _event.AbilityName = newAbilityUnlockedName;
        MMEventManager.TriggerEvent(_event);
    }
}