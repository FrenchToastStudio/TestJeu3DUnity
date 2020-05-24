using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] GameObject menuNiveauTerminer;
    [SerializeField] GameObject controlleurRésoltuion;
    [SerializeField] GameObject textRésultat;
    [SerializeField] GameObject nombreDeCoupJoueur;
    [SerializeField] GameObject nombreDeCoupMinimum;
    [SerializeField] GameObject UIgameplay;
    [SerializeField] GameObject sauvegardeCtrl;


    private int niveauReussi;

    private void Start() {
        if(niveauReussi == null) {
            niveauReussi = 0;
        }
    }

    public void lancer(int nombreDeCoup) {
        UIgameplay.SetActive(false);


        // if(nombreDeCoup <= controlleurRésoltuion.GetComponent<RésolutionCtrl>().getCoupMinimum()){
        //     textRésultat.GetComponent<Text>().text = "Vous avez Réeussi...";
        //     sauvegardeCtrl.GetComponent<SauvegardeCtrl>().débloquéNiveau();
        // } else {
        //     textRésultat.GetComponent<Text>().text = "Vous avez perdu...";
        // }

        // nombreDeCoupJoueur.GetComponent<Text>().text = "Votre nombre de coup: " + nombreDeCoup;
        // nombreDeCoupMinimum.GetComponent<Text>().text = "Nombre de coup minimum: " + controlleurRésoltuion.GetComponent<RésolutionCtrl>().getCoupMinimum();

        // menuNiveauTerminer.SetActive(true);
        // Time.timeScale = 0;
    }

}
