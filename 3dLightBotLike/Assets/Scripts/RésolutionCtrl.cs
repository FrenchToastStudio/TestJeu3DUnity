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
        résolution.GetComponent<ObjetRésolutionCtrl>().setUniteDeplacement(personnage.GetComponent<PersonnageController>().getUniteDeplacement());
        résolution.GetComponent<ObjetRésolutionCtrl>().setHauteurSaut(personnage.GetComponent<PersonnageController>().getHauteurSaut());
        résolution.GetComponent<ObjetRésolutionCtrl>().setUniteDeplacementSaut(personnage.GetComponent<PersonnageController>().getUniteDeplacementSaut());

        listeRésolutions = new List<GameObject>();
        listeRésolutions.Add(résolution);

    }

    // Update is called once per frame
    private void Update() {

        if(listeRésolutions.Count > 0) { 
            foreach(GameObject uneRésolution in listeRésolutions) { 
                if(uneRésolution == null){
                    listeRésolutions.Remove(uneRésolution);
                } else {
                    if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getCompléterNiveau()) {
                        if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup() < coupMinimum){
                            coupMinimum = uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup();
                            Destroy(uneRésolution);
                        }
                    } else {
                        cloner(uneRésolution);
                        Destroy(uneRésolution);
                    }
                }
            }
        }
    }

    private void cloner(GameObject unObjetACloner) {
        unObjetACloner.SetActive(false);
        GameObject clone1 = Instantiate(unObjetACloner) as GameObject;
        clone1.SetActive(true);
        clone1.GetComponent<ObjetRésolutionCtrl>().avancer();
        clone1.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone1 != null)
            listeRésolutions.Add(clone1);

        GameObject clone2 = Instantiate(unObjetACloner) as GameObject;
        clone2.SetActive(true);
        clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        clone2.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone2 != null)
            listeRésolutions.Add(clone2);

        GameObject clone3 = Instantiate(unObjetACloner) as GameObject;
        clone3.SetActive(true);
        clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        clone3.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone3 != null)
            listeRésolutions.Add(clone3);

        GameObject clone4 = Instantiate(unObjetACloner) as GameObject;
        clone4.SetActive(true);
        clone4.GetComponent<ObjetRésolutionCtrl>().sauter();
        clone4.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone4 != null)
            listeRésolutions.Add(clone4);

        GameObject clone5 = Instantiate(unObjetACloner) as GameObject;
        clone5.SetActive(true);
        clone5.GetComponent<ObjetRésolutionCtrl>().sauterGauche();
        clone5.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone5 != null)
            listeRésolutions.Add(clone5);

        GameObject clone6 = Instantiate(unObjetACloner) as GameObject;
        clone6.SetActive(true);
        clone6.GetComponent<ObjetRésolutionCtrl>().sauterDroite();
        clone6.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();
        if(clone6 != null)
            listeRésolutions.Add(clone6);
    }
}
