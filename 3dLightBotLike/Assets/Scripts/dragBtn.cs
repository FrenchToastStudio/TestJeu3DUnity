using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragBtn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private UiController uiController;
    Vector3 positiondepart;
    GameObject containerSequence;
    GameObject containerProcedure;
    RectTransform receveurContainerSequence;
    RectTransform receveurContainerProcedure;
    RawImage imageReceveurSequence;
    RawImage imageReceveurProcedure;

    string layoutDestination;

    public void OnBeginDrag(PointerEventData eventData){
        positiondepart  = transform.localPosition;
        containerSequence = GameObject.Find("ContainerSequence");
        containerProcedure = GameObject.Find("ContainerProcedure");
        receveurContainerSequence = containerSequence.GetComponent<RectTransform>();
        receveurContainerProcedure = containerProcedure.GetComponent<RectTransform>();
        imageReceveurSequence = containerSequence.GetComponent<RawImage>();
        imageReceveurProcedure = containerProcedure.GetComponent<RawImage>();
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;

        if(RectTransformUtility.RectangleContainsScreenPoint(receveurContainerSequence, Input.mousePosition)){
            imageReceveurSequence.color = new Color32(241, 142, 137, 81);
        } else if(RectTransformUtility.RectangleContainsScreenPoint(receveurContainerProcedure, Input.mousePosition)){
            imageReceveurProcedure.color = new Color32(241, 142, 137, 81);
        } else {
            imageReceveurSequence.color = new Color32(167, 216, 167, 81);
            imageReceveurProcedure.color = new Color32(167, 216, 167, 81);
        }

    }

    public void OnEndDrag(PointerEventData eventData){
        transform.localPosition = positiondepart;
        imageReceveurSequence.color = new Color32(167, 216, 167, 81);
        imageReceveurProcedure.color = new Color32(167, 216, 167, 81);
        
        if(RectTransformUtility.RectangleContainsScreenPoint(receveurContainerSequence, Input.mousePosition)){
            layoutDestination = "sequence";
            if(this.gameObject.name.Contains("btnSaut")){
                uiController.setMouvementSaut(layoutDestination);
            } else if(this.gameObject.name.Contains("btnAvance")){
                uiController.setMouvementAvance(layoutDestination);
            } else if(this.gameObject.name.Contains("btnDroite")){
                uiController.setMouvementDroite(layoutDestination);
            } else if(this.gameObject.name.Contains("btnGauche")){
                uiController.setMouvementGauche(layoutDestination);
            }
        } else if(RectTransformUtility.RectangleContainsScreenPoint(receveurContainerProcedure, Input.mousePosition)){
            layoutDestination = "other";
            if(this.gameObject.name.Contains("btnSaut")){
                uiController.setMouvementSaut(layoutDestination);
            } else if(this.gameObject.name.Contains("btnAvance")){
                uiController.setMouvementAvance(layoutDestination);
            } else if(this.gameObject.name.Contains("btnDroite")){
                uiController.setMouvementDroite(layoutDestination);
            } else if(this.gameObject.name.Contains("btnGauche")){
                uiController.setMouvementGauche(layoutDestination);
            }
        }
        
        
        else {
            Debug.Log("end outside");
        }
    }

}
