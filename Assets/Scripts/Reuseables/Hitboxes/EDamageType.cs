using System;

[Flags] public enum EDamageType
{
    None = 0,
    Critical = 1 << 0,
    Healing = 1 << 1,
}