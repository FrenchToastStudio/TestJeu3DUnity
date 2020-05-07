using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    [SerializeField] private GameObject txtgo;
    [SerializeField] private GameObject txtErreur;
    

    [SerializeField] private GameObject btnRestart;
    [SerializeField] private Sprite spriteAvance;
    [SerializeField] private Sprite spriteGauche;
    [SerializeField] private Sprite spriteDroite;
    [SerializeField] private Sprite spriteSaute;

    
    private static List<String> sequence = new List<string>();
    private List<String> listeDestination = new List<string>();
    private static bool modificationAffichage = false;

    void Start(){
        sequence = new List<string>();
    }
    
    void Update(){

        if(modificationAffichage){
            foreach (GameObject btnSequence in GameObject.FindGameObjectsWithTag("btnSequence")){
                // Nettoie l'affichage de la sequence
                Destroy(btnSequence);
                
            }
            
            // Parcours le tableau de sequence pour mettre à jour l'affichage
            for(int i=0; i<sequence.Count; i++){
                txtErreur.SetActive(false);
                switch(sequence[i]){
                    case "Avance":
                        genererBoutonSequence(i, spriteAvance);               
                        break;
                    case "Gauche":
                        genererBoutonSequence(i, spriteGauche);
                        break;
                    case "Droite":
                        genererBoutonSequence(i, spriteDroite);
                        break;
                    case "Saut":
                        genererBoutonSequence(i, spriteSaute);
                        break;
                }
            }
        }
        modificationAffichage = false;
    }

    public void genererBoutonSequence(int numBouton, Sprite sprite){
        GameObject imageObjetAvance = new GameObject();
        Image imageAvance = imageObjetAvance.AddComponent<Image>();
        imageAvance.sprite = sprite;
        imageObjetAvance.tag = "btnSequence";
        imageObjetAvance.name =  numBouton.ToString();
        imageObjetAvance.AddComponent<btnCtrl>();
        imageObjetAvance.GetComponent<RectTransform>().transform.localScale = new Vector2(0.3f,0.3f);
        imageObjetAvance.GetComponent<RectTransform>().SetParent(layout.transform);
        imageObjetAvance.SetActive(true);
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
        if(sequence.Count == 0){
            txtErreur.SetActive(true);
        } else {
            listeDestination = copyList(sequence);
            PersonnageController.SetSequence(sequence);
            txtgo.SetActive(false);
        }
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
        txtgo.SetActive(true);
        PersonnageController.Restart();
    }

    public static void ActionToDelete (int position){
        sequence.RemoveAt(position);
        modificationAffichage = true;
    }

}
