using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] GameObject menuNiveauTerminer;
    [SerializeField] GameObject controlleurRésoltuion;
    [SerializeField] GameObject textRésultat;
    [SerializeField] GameObject nombreDeCoupJoueur;
    [SerializeField] GameObject nombreDeCoupMinimum;


    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "personnagePrincipale") {

            if(col.gameObject.GetComponent<PersonnageController>().getNombreDeCoup() <= controlleurRésoltuion.GetComponent<RésolutionCtrl>().getNombreDeCoup()){
                textRésultat.GetComponent<Text>().text = "Vous avez Réeussi..."
            } else {
                textRésultat.GetComponent<Text>().text = "Vous avez perdu..."
            }
            nombreDeCoupJoueur.GetComponent<Text>().text = "Votre nombre de coup: " + col.gameObject.GetComponent<PersonnageController>().getNombreDeCoup();
            nombreDeCoupJoueur.GetComponent<Text>().text = "Nombre de coup minimum: " + controlleurRésoltuion.GetComponent<RésolutionCtrl>().getNombreDeCoup();

            menuNiveauTerminer.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
