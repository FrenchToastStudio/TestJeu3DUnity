using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiNiveauCtrl : MonoBehaviour
{
    [SerializeField] SauvegardeCtrl sauvegardeCtrl;
    Sauvegarde uneSauvegarde;
    GameObject[] boutonsNiveau;
    // Start is called before the first frame update
    void Start()
    {
        uneSauvegarde = GestionaireSauvegardes.Charger();
    
        boutonsNiveau = GameObject.FindGameObjectsWithTag("btnNiveau");

        for(int i=0; i<uneSauvegarde.débloqué.Count; i++){
            if(uneSauvegarde.débloqué[i] > 0)
            boutonsNiveau[i].GetComponent<Button>().interactable = true;
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
