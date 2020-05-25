using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauvegardeCtrl : MonoBehaviour
{
    Sauvegarde sauvegarde;

    private void Start(){
        sauvegarde = GestionaireSauvegardes.Charger();
    }


    public void débloquéNiveau() {
        sauvegarde.débloqué.Add(0);
        sauvegarde.débloqué[sauvegarde.position + 1] = 1;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

    
    public void changerNiveau(int unePosition) {
        sauvegarde.position = unePosition;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

}
