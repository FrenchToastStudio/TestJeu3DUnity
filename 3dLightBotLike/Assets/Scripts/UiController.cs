using System.Diagnostics.Tracing;
using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject UIgameplay;

    [SerializeField] private GameObject layout;
    [SerializeField] private GameObject btnMouvementAvance;
    [SerializeField] private GameObject btnMouvementSaut;
    [SerializeField] private GameObject btnMouvementGauche;
    [SerializeField] private GameObject btnMouvementDroit;
    [SerializeField] private GameObject btnMouvementGo;
    [SerializeField] private GameObject btnRestart;

    [SerializeField] private Sprite spriteAvance;
    [SerializeField] private Sprite spriteGauche;
    [SerializeField] private Sprite spriteDroite;
    [SerializeField] private Sprite spriteSaute;


    
    private List<String> sequence = new List<string>();
    private List<String> listeDestination = new List<string>();
    private Vector3 espacementEntreBtn = new Vector3(60, 0, 0);
    private static Vector3 imagePosition = new Vector3(-330,175,0);
    private bool modificationAffichage = false;

   void Start()
    {

    }

    void Update(){

        if(modificationAffichage){
            foreach (GameObject btnSequence in GameObject.FindGameObjectsWithTag("btnSequence")){
                Destroy(btnSequence);
                
            }
            
            for(int i=0; i<sequence.Count; i++){
                switch(sequence[i]){
                    case "Avance":
                        GameObject imageObjetAvance = new GameObject();
                        Image imageAvance = imageObjetAvance.AddComponent<Image>();
                        imageAvance.sprite = spriteAvance;
                        imageObjetAvance.tag = "btnSequence";
                        imageObjetAvance.GetComponent<RectTransform>().transform.localScale = new Vector2(0.3f,0.3f);
                        imageObjetAvance.GetComponent<RectTransform>().SetParent(layout.transform);
                        imageObjetAvance.SetActive(true);
                        
                        // EventTrigger trigger = imageObjet.GetComponent<EventTrigger>();
                        // EventTrigger.Entry entry = new EventTrigger.Entry();
                        // entry.eventID = EventTriggerType.PointerClick;
                        // entry.callback.AddListener( (data) => { getInfo((PointerEventData) data); } );
                        // trigger.triggers.Add(entry);
                                   
                        break;
                    case "Gauche":
                        GameObject imageObjetGauche = new GameObject();
                        Image imageGauche = imageObjetGauche.AddComponent<Image>();
                        imageGauche.sprite = spriteGauche;
                        imageObjetGauche.tag = "btnSequence";
                        imageObjetGauche.GetComponent<RectTransform>().transform.localScale = new Vector2(0.25f,0.25f);
                        imageObjetGauche.GetComponent<RectTransform>().SetParent(layout.transform);
                        imageObjetGauche.SetActive(true);
                        break;
                    case "Droite":
                        GameObject imageObjetDroite = new GameObject();
                        Image imageDroite = imageObjetDroite.AddComponent<Image>();
                        imageDroite.sprite = spriteDroite;
                        imageObjetDroite.tag = "btnSequence";
                        imageObjetDroite.GetComponent<RectTransform>().transform.localScale = new Vector2(0.25f,0.25f);
                        imageObjetDroite.GetComponent<RectTransform>().SetParent(layout.transform);
                        imageObjetDroite.SetActive(true);
                        break;
                    case "Saut":
                        GameObject imageObjetSaut = new GameObject();
                        Image imageSaut = imageObjetSaut.AddComponent<Image>();
                        imageSaut.sprite = spriteSaute;
                        imageObjetSaut.tag = "btnSequence";
                        imageObjetSaut.GetComponent<RectTransform>().transform.localScale = new Vector2(0.3f,0.3f);
                        imageObjetSaut.GetComponent<RectTransform>().SetParent(layout.transform);
                        imageObjetSaut.SetActive(true);
                        break;
                }
            }
        }
        modificationAffichage = false;
    }

    public void getInfo(PointerEventData data){
        Debug.Log("clicked");
    }

    public void delBtn(int id){
        sequence.RemoveAt(id);
        modificationAffichage = true;
    }

    public void setMouvementGauche(){
        sequence.Add("Gauche");
        modificationAffichage =true;
    }

    public void setMouvementAvance(){
        sequence.Add("Avance");
        modificationAffichage =true;
    }

    public void setMouvementDroite(){
        sequence.Add("Droite");
        modificationAffichage =true;
    }

    public void setMouvementSaut(){
        sequence.Add("Saut");
        modificationAffichage =true;
    }

    public void LancerSequence(){
        listeDestination = copyList(sequence);
        PersonnageController.SetSequence(sequence);
        print("sequence lancer");
    }

    private List<String> copyList (List<String> listeOriginale){
        List<String> listeDestination = new List<string>();
        foreach(String valeur in listeOriginale){
            listeDestination.Add(valeur);
        }
        return listeDestination;
    }

    public void restart (){
        sequence = new List<string>();
        modificationAffichage = true;
        PersonnageController.Restart();
    }

    // public void addBtnAvance(int i){
    //     imagePosition += espacementEntreBtn;
    //     GameObject uiToggle = Instantiate(btnMouvementAvance) as GameObject;
    //     uiToggle.transform.SetParent(UIgameplay.transform, false);
    //     uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
    //     uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    //     uiToggle.name = i.ToString();
    // }

    // public void addBtnSaut(int i){
    //     imagePosition += espacementEntreBtn;
    //     GameObject uiToggle = Instantiate(btnMouvementSaut) as GameObject;
    //     uiToggle.transform.SetParent(UIgameplay.transform, false);
    //     uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
    //     uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    //     uiToggle.name = i.ToString();
    // }

    // public void addBtnGauche(int i){
    //     imagePosition += espacementEntreBtn;
    //     GameObject uiToggle = Instantiate(btnMouvementGauche) as GameObject;
    //     uiToggle.transform.SetParent(UIgameplay.transform, false);
    //     uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
    //     uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    //     uiToggle.name = i.ToString();
    // }

    // public void addBtnDroit(int i){
    //     imagePosition += espacementEntreBtn;
    //     GameObject uiToggle = Instantiate(btnMouvementDroit) as GameObject;
    //     uiToggle.transform.SetParent(UIgameplay.transform, false);
    //     uiToggle.GetComponent<RectTransform>().anchoredPosition3D = imagePosition;
    //     uiToggle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    //     uiToggle.name = i.ToString();
    // }

}
