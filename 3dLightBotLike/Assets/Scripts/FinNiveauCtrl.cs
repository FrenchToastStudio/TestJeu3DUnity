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
}
