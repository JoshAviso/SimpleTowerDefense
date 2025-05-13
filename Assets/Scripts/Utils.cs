
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
            Debug.LogWarning("[WARN]: " + warningString);
            return false;
        }

        return true;
    }

}