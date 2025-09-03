
using UnityEditor.EditorTools;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Manager Settings")]
    public bool Retain_Between_Scenes = false;
    public bool Debug_Mode = false;

#region Singleton
    private static CombatManager _instance = null;
    public static CombatManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newObj = new GameObject("CombatManager");
                newObj.AddComponent<CombatManager>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        if (gameObject.transform.parent == null && Retain_Between_Scenes)
            DontDestroyOnLoad(gameObject);
    }
    public void DestroyObject() { _instance = null; Destroy(gameObject); }
#endregion
}
