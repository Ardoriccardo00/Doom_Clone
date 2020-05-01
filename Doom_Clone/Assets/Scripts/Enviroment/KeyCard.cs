using System;
using UnityEngine;

public enum KeyCardColor
{
    none,
    red,
    yellow,
    blue
}

[CreateAssetMenu(fileName = "New Keycard")]
public class KeyCard : ScriptableObject
{
    public KeyCardColor keyCardColor;
} 