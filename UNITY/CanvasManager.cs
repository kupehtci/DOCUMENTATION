using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is for managing the Canvas items for switching between minigames
/// </summary>
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject[]   _canvases           = null;
    [SerializeField] private int            _indexCanvasActive  = 0;




    /// <summary>
    /// Change to the next canvas in the _canvases array if there is one more
    /// </summary>
    public void NextCanvas()
    {
        if(_indexCanvasActive < _canvases.Length)
        {
            _canvases[_indexCanvasActive].SetActive(false);
            _indexCanvasActive++;
            _canvases[_indexCanvasActive].SetActive(true); 
        }
    }

    /// <summary>
    /// Change to the previous canvas in the _canvases array if there is one more
    /// </summary>
    public void PreviousCanvas()
    {
        if(_indexCanvasActive > 0 && _canvases.Length > 0)
        {
            _canvases[_indexCanvasActive].SetActive(false);
            _indexCanvasActive--;
            _canvases[_indexCanvasActive].SetActive(true);
        }
    }


    #region GETTERS AND SETTERS

    public int GetIndexCanvasActive()
    {
        return _indexCanvasActive; 
    }

    public GameObject GetCanvasObjActive()
    {
        return _canvases[_indexCanvasActive]; 
    }

    #endregion 
}
