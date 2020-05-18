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


    private int niveauReussi;

    void update(){

    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "personnagePrincipale") {

            UIgameplay.SetActive(false);

            if(col.gameObject.GetComponent<PersonnageController>().getNombreDeCoup() <= controlleurRésoltuion.GetComponent<RésolutionCtrl>().getCoupMinimum()){
                textRésultat.GetComponent<Text>().text = "Vous avez Réeussi...";
            } else {
                textRésultat.GetComponent<Text>().text = "Vous avez perdu...";
            }
            nombreDeCoupJoueur.GetComponent<Text>().text = "Votre nombre de coup: " + col.gameObject.GetComponent<PersonnageController>().getNombreDeCoup();
            nombreDeCoupMinimum.GetComponent<Text>().text = "Nombre de coup minimum: " + controlleurRésoltuion.GetComponent<RésolutionCtrl>().getCoupMinimum();

            menuNiveauTerminer.SetActive(true);
            niveauReussi += 1;
            Time.timeScale = 0;
        }
    }

}
