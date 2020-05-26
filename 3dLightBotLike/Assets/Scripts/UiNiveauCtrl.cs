using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiNiveauCtrl : MonoBehaviour
{
    [SerializeField] SauvegardeCtrl sauvegardeCtrl;
    
    Sauvegarde uneSauvegarde;
    GameObject[] boutonsNiveau;

    void Start()
    {
        uneSauvegarde = GestionaireSauvegardes.Charger();
        boutonsNiveau = GameObject.FindGameObjectsWithTag("btnNiveau");
        rafraichirAffichage();
    }

    public void intialiserSauvegarde(){
        GestionaireSauvegardes.initialiserSauvegarde();
        uneSauvegarde = GestionaireSauvegardes.Charger();
        rafraichirAffichage();
    }

    public void rafraichirAffichage(){
        foreach (GameObject bouton in boutonsNiveau){
            bouton.GetComponent<Button>().interactable = false;
        }
        for(int i=0; i<uneSauvegarde.débloqué.Count; i++){
            if(uneSauvegarde.débloqué[i] > 0)
            boutonsNiveau[i].GetComponent<Button>().interactable = true;
        }
    }

}
