using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RésolutionCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject personnage;
    [SerializeField]
    private GameObject résolution;
    [SerializeField]
    private GameObject EcranChargement;


    List<GameObject> listeRésolutions;

    int coupMinimum = 0;

    // Start is called before the first frame update
    private void Start() {

        listeRésolutions = new List<GameObject>();
        listeRésolutions.Add(résolution);

        personnage.SetActive(false);

    }

    // Update is called once per frame
    private void LateUpdate() {

        if((coupMinimum == 0)) { 
            foreach(GameObject uneRésolution in listeRésolutions) {
                if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getÀDétruire()){
                    Destroy(uneRésolution);
                    listeRésolutions.Remove(uneRésolution);
                } else if(!uneRésolution.GetComponent<ObjetRésolutionCtrl>().getEnMouvement()){
                    if(uneRésolution.GetComponent<ObjetRésolutionCtrl>().getCompléterNiveau()) {
                        coupMinimum = uneRésolution.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup();
                        Destroy(uneRésolution);
                    } else {
                        cloner(uneRésolution);
                        Destroy(uneRésolution);
                        listeRésolutions.Remove(uneRésolution);
                    }
                }
            }
        } else {
            foreach(GameObject uneRésolution in listeRésolutions) {
                Destroy(uneRésolution);
            }
            personnage.SetActive(true);
            EcranChargement.SetActive(false);
        }
    }

    private void cloner(GameObject unObjetACloner) {
        GameObject clone1 = Instantiate(unObjetACloner) as GameObject;

        clone1.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone1.GetComponent<ObjetRésolutionCtrl>().avancer();
        listeRésolutions.Add(clone1);

        GameObject clone2 = Instantiate(unObjetACloner) as GameObject;

        clone2.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone2.GetComponent<ObjetRésolutionCtrl>().tournerGauche();
        listeRésolutions.Add(clone2);

        GameObject clone3 = Instantiate(unObjetACloner) as GameObject;

        clone3.GetComponent<ObjetRésolutionCtrl>().setNombreDeCoup(unObjetACloner.GetComponent<ObjetRésolutionCtrl>().getNombreDeCoup());
        clone3.GetComponent<ObjetRésolutionCtrl>().tournerDroite();
        listeRésolutions.Add(clone3);

    }

    public int getCoupMinimum() {
        return coupMinimum;
    }
}
