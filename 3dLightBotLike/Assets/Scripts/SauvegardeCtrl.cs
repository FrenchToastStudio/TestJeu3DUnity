using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SauvegardeCtrl : MonoBehaviour
{
    Sauvegarde sauvegarde;
    [SerializeField]
    List<GameObject> listeBoutonNiveau;
    // Start is called before the first frame update
    private void Start()
    {
        sauvegarde = GestionaireSauvegardes.Charger();
        sauvegarde.débloqué[0] = 1;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);

        //rend les bouton interactable si il sont débloqué
        if(listeBoutonNiveau.Count > 0) {
            for(int i = 0; sauvegarde.débloqué.Count > i; i++) {
                listeBoutonNiveau[i].GetComponent<Button>().interactable = true;
            }
        }
    }


    public void débloquéNiveau() {
        sauvegarde.débloqué[sauvegarde.position] = 1;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

    public void changerNiveau(int unePosition) {
        sauvegarde.position = unePosition;
        GestionaireSauvegardes.Sauvegarder(sauvegarde);
    }

}
