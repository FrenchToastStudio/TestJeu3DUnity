﻿using System.Runtime.CompilerServices;
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
    [SerializeField] private GameObject layoutSequence;
    [SerializeField] private GameObject layoutProcedure;
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
    private static List<String> procedure;
    private List<String> listeDestination = new List<string>();
    private static bool modificationAffichage = false;

    void Start(){
        sequence = new List<string>();
        procedure = new List<string>();
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
                        genererBoutonSequence(i, spriteAvance, layoutSequence);               
                        break;
                    case "Gauche":
                        genererBoutonSequence(i, spriteGauche, layoutSequence);
                        break;
                    case "Droite":
                        genererBoutonSequence(i, spriteDroite, layoutSequence);
                        break;
                    case "Saut":
                        genererBoutonSequence(i, spriteSaute, layoutSequence);
                        break;
                }
            }

            // Parcours le tableau de procedure pour mettre à jour l'affichage
            for(int i=0; i<procedure.Count; i++){
                txtErreur.SetActive(false);
                switch(procedure[i]){
                    case "Avance":
                        genererBoutonSequence(i, spriteAvance, layoutProcedure);               
                        break;
                    case "Gauche":
                        genererBoutonSequence(i, spriteGauche, layoutProcedure);
                        break;
                    case "Droite":
                        genererBoutonSequence(i, spriteDroite, layoutProcedure);
                        break;
                    case "Saut":
                        genererBoutonSequence(i, spriteSaute, layoutProcedure);
                        break;
                }
            }
            Debug.Log(sequence.Count);
            Debug.Log(procedure.Count);
        }
        modificationAffichage = false;
    }

    public void genererBoutonSequence(int numBouton, Sprite sprite, GameObject layoutContainer){
        GameObject imageObjetAvance = new GameObject();
        Image imageAvance = imageObjetAvance.AddComponent<Image>();
        imageAvance.sprite = sprite;
        imageObjetAvance.tag = "btnSequence";
        imageObjetAvance.name =  numBouton.ToString();
        imageObjetAvance.AddComponent<btnCtrl>();
        imageObjetAvance.GetComponent<RectTransform>().transform.localScale = new Vector2(0.2f,0.2f);
        imageObjetAvance.GetComponent<RectTransform>().SetParent(layoutContainer.transform);
        imageObjetAvance.SetActive(true);
    }

    public void setMouvementGauche(String layoutDestination){
        if(layoutDestination == "sequence")
            sequence.Add("Gauche");
        else
            procedure.Add("Gauche");
        modificationAffichage =true;
    }

    public void setMouvementAvance(String layoutDestination){
        if(layoutDestination == "sequence")
            sequence.Add("Avance");
        else
            procedure.Add("Avance");
        modificationAffichage =true;
    }

    public void setMouvementDroite(String layoutDestination){
        if(layoutDestination == "sequence")
            sequence.Add("Droite");
        else
            procedure.Add("Droite");
        modificationAffichage =true;
    }

    public void setMouvementSaut(String layoutDestination){
        if(layoutDestination == "sequence")
            sequence.Add("Saut");
        else
            procedure.Add("Saut");
        modificationAffichage =true;
    }

    public void LancerSequence(){
        print("go");
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
        Debug.Log();
        sequence.RemoveAt(position);
        modificationAffichage = true;
    }

}
