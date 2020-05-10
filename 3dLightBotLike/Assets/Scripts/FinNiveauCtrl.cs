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
            Time.timeScale = 0;
        }
    }

}
