using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNiveauCtrl : MonoBehaviour
{
    [SerializeField] GameObject menuNiveauTerminer;

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "personnagePrincipale") {
            menuNiveauTerminer.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
