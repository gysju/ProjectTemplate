using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class BulletData : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif

    public FloatReference Velocity;
    public FloatReference DamageAmount;

    public UnityEvent OnAwak;
    public UnityEvent OnDest;
}
