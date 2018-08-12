using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public bool UseDefaultValueAtStart = false;
    public float DefaultValue;
    public float Value;

    public void Awake()
    {
        if (UseDefaultValueAtStart)
            Value = DefaultValue;
    }

    public void SetValue(float value)
    {
        Value = value;
    }

    public void SetValue(FloatVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
    }
}