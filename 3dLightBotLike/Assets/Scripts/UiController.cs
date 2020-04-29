using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject UIgameplay;

    [SerializeField]
    private GameObject btnMouvementAvance;

    [SerializeField]
    private GameObject btnMouvementSaut;

    [SerializeField]
    private GameObject btnMouvementGauche;

    [SerializeField]
    private GameObject btnMouvementDroit;


    private Vector3 espacementEntreBtn = new Vector3(60, 0, 0);
    private static Vector3 imagePosition = new Vector3(-330,175,0);


    public void addBtnAvance(){
        imagePosition += espacementEntreBtn;
        GameObject uiToggle = Instantiate(btnMouvementAvance) as GameObject;
        uiToggle.transform.SetParent(UIgameplay.transform, false);
        //Move to another position?
        uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
        //Re-scale?
        uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void addBtnSaut(){
        imagePosition += espacementEntreBtn;
        GameObject uiToggle = Instantiate(btnMouvementSaut) as GameObject;
        uiToggle.transform.SetParent(UIgameplay.transform, false);
        //Move to another position?
        uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
        //Re-scale?
        uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void addBtnGauche(){
        imagePosition += espacementEntreBtn;
        GameObject uiToggle = Instantiate(btnMouvementGauche) as GameObject;
        uiToggle.transform.SetParent(UIgameplay.transform, false);
        //Move to another position?
        uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
        //Re-scale?
        uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void addBtnDroit(){
        imagePosition += espacementEntreBtn;
        GameObject uiToggle = Instantiate(btnMouvementDroit) as GameObject;
        uiToggle.transform.SetParent(UIgameplay.transform, false);
        //Move to another position?
        uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
        //Re-scale?
        uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    







}
