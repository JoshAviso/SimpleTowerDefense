using System;

[Flags]
public enum EHitboxLayer
{
    None = 0,
    Player = 1 << 0,
    Enemy = 1 << 1,
    Environment = 1 << 2
}
