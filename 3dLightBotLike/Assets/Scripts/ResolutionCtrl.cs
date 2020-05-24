using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionCtrl : MonoBehaviour
{
    private List <GameObject> parcours;
    private GameObject personnage;
    int nbrMouvement = 0;


    // Start is called before the first frame update
    void Start()
    {
        personnage = GameObject.FindGameObjectWithTag("personnagePrincipale");
        Vector3 personnagePosition = personnage.transform.position;
        Debug.Log(personnagePosition);
        GameObject[] tabParcours = GameObject.FindGameObjectsWithTag("casesParcours");
        parcours = tabParcours.OfType<GameObject>().ToList();
        Debug.Log(parcours.Count);
        
        parcours = parcours.OrderBy(x => Vector3.Distance(x.transform.position, personnagePosition)).ToList();

        foreach(GameObject caseParcours in parcours){
            Debug.Log(caseParcours.name);    
        }

        for(int i=1; i<parcours.Count; i++){
            if(parcours[i-1].transform.position.y - parcours[i].transform.position.y > 1){
                nbrMouvement++;
            } else {
                nbrMouvement+=2;
            }
        }

        Debug.Log(nbrMouvement);
            


    
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
