﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauvegardeCtrl : MonoBehaviour
{
    Sauvegarde sauvegarde;

    private void Start(){
        sauvegarde = GestionaireSauvegardes.Charger();
    }


    public void débloquéNiveau(int score) {
        if(sauvegarde.débloqué[sauvegarde.position] == 1 || sauvegarde.débloqué[sauvegarde.position] > score)
            sauvegarde.débloqué[sauvegarde.position] = score;
        if(sauvegarde.débloqué[sauvegarde.position + 1] == null)
            sauvegarde.débloqué.Add(1);
        else
            sauvegarde.débloqué[sauvegarde.position + 1] = 1;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

    
    public void changerNiveau(int unePosition) {
        sauvegarde.position = unePosition;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

    public int getMeilleurScore(){
        sauvegarde = GestionaireSauvegardes.Charger();
        return sauvegarde.débloqué[sauvegarde.position];
    }

}
