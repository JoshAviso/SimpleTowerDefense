using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Serializable] public enum GridOriginPosition {
        TopLeft, TopRight, BottomLeft, BottomRight, Centered
    }

    [SerializeReference] private GameObject _cellTemplate;
    [SerializeField] private float _cellSize = 1.0f;
    [SerializeField] private float _cellGap = 0.1f;
    [SerializeField] private Vector2 _gridDimensions = new();
    [SerializeField] private GridOriginPosition _originPosition;
    [SerializeField, HideInInspector] private List<GameObject> _generatedCells = new();

    [EditorButton("Generate New Grid")]
    private void GenerateGrid()
    {
        foreach(GameObject gameObject in _generatedCells)
            DestroyImmediate(gameObject);

        _generatedCells.Clear();

        Vector3 standardOrigin = GetGenStandardOrigin();
        for(int i = 0; i < _gridDimensions.x; i++){
            for(int j = 0; j < _gridDimensions.y; j++){
                GameObject cell = GameObject.Instantiate(
                    _cellTemplate, new Vector3(standardOrigin.x + i * (_cellSize + _cellGap), standardOrigin.y, standardOrigin.z - j * (_cellSize + _cellGap)), Quaternion.identity);

                if(!Utils.TryGetComponentNullCheck(cell, out GridCell cellScript, "No GridCell script in template object")){
                    DestroyImmediate(cell);
                    continue;
                }

                cellScript.SetDimension(_cellSize);
                cell.transform.SetParent(transform);
                _generatedCells.Add(cell);
            }
        }
    }

    private Vector3 GetGenStandardOrigin(){
        switch(_originPosition){
            case GridOriginPosition.TopLeft:
                return transform.position;
            case GridOriginPosition.TopRight: {
                Vector3 output = transform.position;
                output.x -= (_gridDimensions.x - 1) * (_cellSize + _cellGap);
                return output;
            }
            case GridOriginPosition.BottomLeft: {
                Vector3 output = transform.position;
                output.z += (_gridDimensions.y - 1) * (_cellSize + _cellGap);
                return output;
            }
            case GridOriginPosition.BottomRight: {
                Vector3 output = transform.position;
                output.x -= (_gridDimensions.x - 1) * (_cellSize + _cellGap);
                output.z += (_gridDimensions.y - 1) * (_cellSize + _cellGap);
                return output;
            }   
            case GridOriginPosition.Centered: {
                Vector3 output = transform.position;
                output.x -= (_gridDimensions.x - 1) * (_cellSize + _cellGap) / 2.0f;
                output.z += (_gridDimensions.y - 1) * (_cellSize + _cellGap) / 2.0f;
                return output;
            }
        }

        return transform.position;
    }
}
