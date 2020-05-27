using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] SauvegardeCtrl sauvegardeCtrl;
    [SerializeField] SceneCtrl SceneCtrl;
    [SerializeField] private GameObject uiGamePlay;
    [SerializeField] private GameObject uiNiveauReussi;
    [SerializeField] private GameObject textResumeValeur;
    [SerializeField] private GameObject textRecordBattu;

    private static int nbrDeCoupUtilisé;
    
    void OnCollisionEnter(Collision collision){
        Time.timeScale = 0;

        if(sauvegardeCtrl.getMeilleurScore() > nbrDeCoupUtilisé)
            textRecordBattu.SetActive(true);

        sauvegardeCtrl.GetComponent<SauvegardeCtrl>().débloquéNiveau(nbrDeCoupUtilisé);

        uiGamePlay.SetActive(false);
        uiNiveauReussi.SetActive(true);
        textResumeValeur.GetComponent<Text>().text = nbrDeCoupUtilisé.ToString() + " coups";
          
    }

    public static void setNbrCoupUtilisé(int nbrCoup){
        nbrDeCoupUtilisé = nbrCoup;
        Debug.Log("coup " + nbrDeCoupUtilisé);
    }


}
