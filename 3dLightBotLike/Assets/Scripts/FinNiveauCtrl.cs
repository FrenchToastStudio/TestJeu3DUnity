using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] SauvegardeCtrl sauvegardeCtrl;
    [SerializeField] SceneCtrl SceneCtrl;

    private static int nbrDeCoupUtilisé;
    
    void OnCollisionEnter(Collision collision){
        Time.timeScale = 0;
        sauvegardeCtrl.GetComponent<SauvegardeCtrl>().débloquéNiveau(nbrDeCoupUtilisé);
        SceneCtrl.GetComponent<SceneCtrl>().chargerScene("AccueilInterNiveau");
    }

    public static void setNbrCoupUtilisé(int nbrCoup){
        nbrDeCoupUtilisé = nbrCoup;
        Debug.Log("coup " + nbrDeCoupUtilisé);
    }


}
