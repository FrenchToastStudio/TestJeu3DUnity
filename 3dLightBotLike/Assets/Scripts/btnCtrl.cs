using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnCtrl : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData e){

        UiController.ActionToDelete(Int32.Parse(name));

    }
    
}
