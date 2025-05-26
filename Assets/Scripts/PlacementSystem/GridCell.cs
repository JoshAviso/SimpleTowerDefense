using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _displayCube;
    private MeshRenderer _displayCubeDisplayMesh;
    private bool _isPlayerInside = false;
    private int _intersectingCount = 0;
    private bool _hasIntersecting {
        get { return _intersectingCount > 0; }
    }

    void Start()
    {

        if(_displayCube != null)
            Utils.TryGetComponentNullCheck(_displayCube, out _displayCubeDisplayMesh, "No material to display cube!");

        Init();
        HideDisplayCube();
    }

    public void SetDimension(float size){
        float originalDepth = _displayCube.transform.localScale.y;
        _displayCube.transform.localScale = new(size, originalDepth, size);
        if(Utils.TryGetComponentNullCheck(this.gameObject, out BoxCollider collider, "GridCell missing box collider."))
            collider.size = new(size, originalDepth, size);
    }

    private void ShowDisplayCube(GridManager.GridCellDisplayCubeStyle displayStyle){        
        Material targetMat = GridManager.Instance.GetDisplayMatReference(displayStyle);
        if(targetMat == null){
            HideDisplayCube();
            return;
        }

        List<Material> targetMatList = new(){
            targetMat
        };
        _displayCubeDisplayMesh.SetMaterials(targetMatList);   
        _displayCube.SetActive(true);
    }

    private void HideDisplayCube(){
        _displayCube.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!_isPlayerInside){
            if(_hasIntersecting)
                ShowDisplayCube(GridManager.GridCellDisplayCubeStyle.Bad);
            else
                ShowDisplayCube(GridManager.GridCellDisplayCubeStyle.Good);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideDisplayCube();
    }

    public void OnTriggerEnter(Collider other)
    {
        _intersectingCount ++;
        if(Utils.ParentHasComponent<PlayerController>(other)){
            _isPlayerInside = true;
        }      
    }

    public void OnTriggerExit(Collider other)
    {
        if(--_intersectingCount <= 0)
            _intersectingCount = 0;

        if(Utils.ParentHasComponent<PlayerController>(other)){
            _isPlayerInside = false;
        }      
    }

    private void Init()
    {
        _intersectingCount = 0;
    }
}
