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
    [SerializeField] private GameObject layoutSequence;
    [SerializeField] private GameObject layoutProcedure;
    [SerializeField] private GameObject btnMouvementAvance;
    [SerializeField] private GameObject btnMouvementSaut;
    [SerializeField] private GameObject btnMouvementGauche;
    [SerializeField] private GameObject btnMouvementDroit;
    [SerializeField] private GameObject btnMouvementGo;
    [SerializeField] private GameObject txtgo;
    [SerializeField] private GameObject txtErreur;
    [SerializeField] private GameObject txtCoup;
    [SerializeField] private GameObject txtResumeCoup;
    [SerializeField] private GameObject textNbrCoupMaxValeur;
    [SerializeField] private GameObject textRecord;
    [SerializeField] private GameObject textRecordValeur;

    [SerializeField] SauvegardeCtrl sauvegardeCtrl;

    [SerializeField] private GameObject btnRestart;
    [SerializeField] private Sprite spriteAvance;
    [SerializeField] private Sprite spriteGauche;
    [SerializeField] private Sprite spriteDroite;
    [SerializeField] private Sprite spriteSaute;
    [SerializeField] private Sprite spriteProcedure;

    
    private static List<String> sequence = new List<string>();
    private static List<String> procedure;
    private List<String> listeDestination = new List<string>();
    private static bool modificationAffichage = false;

    void Start(){
        sequence = new List<string>();
        procedure = new List<string>();

        // Affichage du meilleur score si une sauvegarde du niveau existe déjà
        if (sauvegardeCtrl.getMeilleurScore() > 1){
            textRecord.SetActive(true);
            textRecordValeur.GetComponent<Text>().text = sauvegardeCtrl.getMeilleurScore().ToString();
        }
            
    }
    
    void Update(){

        if(modificationAffichage){

            foreach (GameObject btnSequence in GameObject.FindGameObjectsWithTag("btnSequence")){
                // Nettoie l'affichage de la sequence
                Destroy(btnSequence);
                txtCoup.SetActive(false);
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
                    case "Procedure":
                        genererBoutonSequence(i, spriteProcedure, layoutSequence);
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
        imageObjetAvance.GetComponent<RectTransform>().transform.localScale = new Vector2(1f,1f);
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
        Debug.Log(ResolutionCtrl.getNbrCoupMaximum());
        if(sequence.Count == 0){
            txtErreur.SetActive(true);
        } else if(sequence.Count > ResolutionCtrl.getNbrCoupMaximum()){
            txtCoup.SetActive(true);
            textNbrCoupMaxValeur.GetComponent<Text>().text = ResolutionCtrl.getNbrCoupMaximum().ToString();
            txtResumeCoup.SetActive(true);
        } else {
            listeDestination = copyList(sequence);
            PersonnageController.SetSequenceComplete(sequence, procedure);
            FinNiveauCtrl.setNbrCoupUtilisé(sequence.Count);
            txtgo.SetActive(false);
        }
    }

    public void addProcedure(){
        sequence.Add("Procedure");
        modificationAffichage =true;
    }


    private List<String> copyList (List<String> listeOriginale){
        List<String> listeDestination = new List<string>();
        foreach(String valeur in listeOriginale){
            listeDestination.Add(valeur);
        }
        return listeDestination;
    }

    // Initialise le personnage à sa position de départ
    public void restart (){
        sequence = listeDestination;
        PersonnageController.SetSequenceComplete(sequence, procedure);
        txtgo.SetActive(true);
        PersonnageController.Restart();
    }

    // Methode qui permet d'effacer une entrée dans la sequence et demande la mise à jour de l'affichage
    public static void ActionToDelete (int position, string nomListe){
        if(nomListe == "ContainerSequence")
            sequence.RemoveAt(position);
        else
            procedure.RemoveAt(position);
        modificationAffichage = true;
    }

    public static void reset(){
        sequence = new List<string>();
        procedure = new List<string>();
        PersonnageController.reset();
    }

}
