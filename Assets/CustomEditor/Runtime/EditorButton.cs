using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class EditorButton : PropertyAttribute
{
    public string ButtonLabel { get; private set; }
    public EditorButton(string label){
        ButtonLabel = label;
    }
}
