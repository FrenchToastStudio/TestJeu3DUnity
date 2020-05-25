using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] SauvegardeCtrl sauvegardeCtrl;
    [SerializeField] SceneCtrl SceneCtrl;
    
    void OnCollisionEnter(Collision collision){
        Time.timeScale = 0;
        sauvegardeCtrl.GetComponent<SauvegardeCtrl>().débloquéNiveau();
        SceneCtrl.GetComponent<SceneCtrl>().chargerScene("AccueilInterNiveau");
    }



    // public void lancer(int nombreDeCoup) {
    //     UIgameplay.SetActive(false);


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
    // }

}
