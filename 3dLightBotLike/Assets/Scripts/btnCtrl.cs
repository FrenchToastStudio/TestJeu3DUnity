using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class btnCtrl : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData e){

        // Listener sur le click dans la sequence pour effacer l'entrée
        UiController.ActionToDelete(Int32.Parse(name), this.gameObject.transform.parent.name);

    }
    
}
