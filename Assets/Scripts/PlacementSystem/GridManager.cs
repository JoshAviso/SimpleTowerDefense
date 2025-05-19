using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;

public class GridManager : MonoBehaviour
{
    [Serializable] public enum GridCellDisplayCubeStyle {
        Good, Bad
    }

    [SerializedDictionary("Display Style", "Material"), SerializeReference] private SerializedDictionary<GridCellDisplayCubeStyle, Material> _gridCellStyleMats = new();

    public Material GetDisplayMatReference(GridCellDisplayCubeStyle style){
        if(!Utils.GetMapValue(_gridCellStyleMats, style, out Material targetMat))
            return null;

        return targetMat;
    }

    public static GridManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null){
            Instance = this;
        } else {
            Destroy(this);
        }
    }
}
