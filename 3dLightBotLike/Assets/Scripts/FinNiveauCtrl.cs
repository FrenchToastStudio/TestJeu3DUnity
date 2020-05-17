using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] GameObject menuNiveauTerminer;

    private int niveauReussi;

    void update(){

    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "personnagePrincipale") {
            menuNiveauTerminer.SetActive(true);
            niveauReussi += 1;
            Time.timeScale = 0;
        }
    }

}
