using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlFinNiveau : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "personnagePrincipale") {
            menuNiveauTerminer.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
