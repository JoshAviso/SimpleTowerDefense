
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static bool TryGetComponentNullCheck<T>(MonoBehaviour script, out T result, string warningString){ 
        return TryGetComponentNullCheck<T>(script.gameObject, out result, warningString);
    }

    public static bool TryGetComponentNullCheck<T>(GameObject gameObject, out T result, string warningString){
        if(gameObject == null){
            Debug.LogWarning("[WARN]: Null game object");
            result = default(T);
            return false;
        }

        if(!gameObject.TryGetComponent<T>(out result)){
            if(!String.IsNullOrWhiteSpace(warningString))
                Debug.LogWarning("[WARN]: " + warningString);
            return false;
        }

        return true;
    }

    public static bool GetMapValue<T,T2>(Dictionary<T,T2> map, T Key, out T2 outputVal){
        if(map == null){
            Debug.LogWarning("[WARN]: Null map");
            outputVal = default(T2);
            return false;
        }

        if(!map.ContainsKey(Key)){
            Debug.LogWarning($"[WARN]: No key ({Key.ToString()}) in map ({map})");
            outputVal = default(T2);
            return false;
        }

        outputVal = map[Key];
        return true;
    }

    public static bool IsPlayer<T>(GameObject gameObject){
        return gameObject.GetComponentInParent<T>() != null;
    }

}