
using UnityEngine;
using UnityEngine.AI;

public class BattleController : MonoBehaviour
{

    #region Singleton
    private static BattleController _instance = null;
    public static BattleController Instance { get { return _instance; } }
    void Start()
    {
        if (_instance != null) { Destroy(this); return; }
        _instance = this;
    }
    void OnDestroy()
    {
        _instance = null;
    }
    #endregion
}
