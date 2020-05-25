using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragReceiver : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData){

        RectTransform containerSequence = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(containerSequence, Input.mousePosition))
            Debug.Log("in");


    }




}
