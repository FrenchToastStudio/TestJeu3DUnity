using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RésolutionCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject personnage;
    [SerializeField]
    private GameObject résolution;


    List<GameObject> listeRésolutions;

    int coupMinimum = 0;

    // Start is called before the first frame update
    private void Start() {
        résolution.GetComponent<ObjetRésolutionCtrl>().setUniteDeplacement = personnage.GetComponent<PersonnageController>().getUniteDeplacement();
        résolution.GetComponent<ObjetRésolutionCtrl>().setHauteurSaut = personnage.GetComponent<PersonnageController>().getHauteurSaut();
        résolution.GetComponent<ObjetRésolutionCtrl>().setUniteDeplacementSaut = personnage.GetComponent<PersonnageController>().getUniteDeplacementSaut();

        listeRésolutions = new List<GameObject>();
        listeRésolutions.add(résolution);

    }

    // Update is called once per frame
    private void Update() {

        if(listeRésolutions.Count > 0) { 
            foreach(GameObject uneRésolution in listeRésolutions) { 
                if(uneRésolution == null){
                    listeRésolutions.Remove(uneRésolution);
                } else {
                    if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getCompléterNiveau()) {
                        if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup() < nombreDeCoup){
                            coupMinimum = uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup();
                            Destroy(uneRésolution);
                        }
                    } else {
                        cloner(uneRésolution);
                    }
                }
            }
        }
    }

    private void cloner(GameObject unObjetACloner) {
        GameObject clone1 = Instantiate(unObjetACloner) as GameObject;
        clone1.GetComponent<ObjetRésolutionCtrl>().avancer();
        clone1.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone2 = Instantiate(unObjetACloner) as GameObject;
        clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        clone2.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone3 = Instantiate(unObjetACloner) as GameObject;
        clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        clone3.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone4 = Instantiate(unObjetACloner) as GameObject;
        clone1.GetComponent<ObjetRésolutionCtrl>().sauter();
        clone4.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone5 = Instantiate(unObjetACloner) as GameObject;
        clone1.GetComponent<ObjetRésolutionCtrl>().sauterGauche();
        clone5.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();


        GameObject clone6 = Instantiate(unObjetACloner) as GameObject;
        clone1.GetComponent<ObjetRésolutionCtrl>().sauterDroite();
        clone6.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

    }
}
