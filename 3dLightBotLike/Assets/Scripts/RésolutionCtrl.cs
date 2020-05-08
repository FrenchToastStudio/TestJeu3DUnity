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

        personnage.SetActive(false);

    }

    // Update is called once per frame
    private void Update() {

        if(listeRésolutions.Count > 0) { 
            foreach(GameObject uneRésolution in listeRésolutions) { 
                if(uneRésolution == null){
                    listeRésolutions.Remove(uneRésolution);
                } else {
                    if(!uneRésolution.GetComponent<ObjetRésolutionCtrl>().getEnMouvement()) {
                        if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getCompléterNiveau()) {
                            if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup() < coupMinimum){
                                coupMinimum = uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup();
                                Destroy(uneRésolution);
                                Debug.Log("Réeussi");
                            }
                        } else {
                            cloner(uneRésolution);
                            Destroy(uneRésolution);
                        }
                    }
                }
            }
        } else {
            personnage.SetActive(true);
        }
    }

    private void cloner(GameObject unObjetACloner) {
        unObjetACloner.SetActive(false);
        GameObject clone1 = Instantiate(unObjetACloner) as GameObject;
        clone1.SetActive(true);
        clone1.GetComponent<ObjetRésolutionCtrl>().avancer();
        if(clone1 != null)
            listeRésolutions.Add(clone1);
            clone1.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone2 = Instantiate(unObjetACloner) as GameObject;
        clone2.SetActive(true);
        clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        if(clone2 != null)
            listeRésolutions.Add(clone2);
            clone2.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();

        GameObject clone3 = Instantiate(unObjetACloner) as GameObject;
        clone3.SetActive(true);
        clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        if(clone3 != null)
            listeRésolutions.Add(clone3);
            clone3.GetComponent<ObjetRésolutionCtrl>().ajouterCoup();


    }
}
