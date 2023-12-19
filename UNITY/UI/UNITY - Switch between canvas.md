#CSHARP #UNITY 
## INTRODUCTION 

A simple way to switch in a menu, or stages in a UI base game, can be done by having an <span style="color:f5a5f5">Canvas array</span> and starting with the first one, change forward or backwards between them by activating or deactivating them. 
#### SCRIPT

```CSHARP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

```

##### VARIABLES

You only need two variables at least: 

* `_canvases` array of canvas for activating and deactivating them 
* `_indexCanvasActive` keeps the index of the canvas that is active to be able to move forward or backwards in the array. 
_