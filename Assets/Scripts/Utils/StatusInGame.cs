using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public static class StatusInGame
{
    private static StatusGame _statusGame;

    public static StatusGame Status
    {
        get => _statusGame;
        set => _statusGame = value;
    }
    
    // private static void SetStaus(StatusGame status)
    // {
    //     _statusGame = status;
    // }
    //
    // public static StatusGame GetStus()
    // {
    //     return _statusGame;
    // }
}