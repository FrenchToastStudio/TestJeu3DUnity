using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionCtrl : MonoBehaviour
{
    private List <GameObject> parcours;
    private GameObject personnage;
    private static int nbrMouvement = 0;


    // Start is called before the first frame update
    void Start()
    {
        personnage = GameObject.FindGameObjectWithTag("personnagePrincipale");
        Vector3 personnagePosition = personnage.transform.position;

        GameObject[] tabParcours = GameObject.FindGameObjectsWithTag("casesParcours");
        parcours = tabParcours.OfType<GameObject>().ToList();
        parcours = parcours.OrderBy(x => Vector3.Distance(x.transform.position, personnagePosition)).ToList();

        List <string> sequencesPrevu = new List<string>();
        float[] angleInit = new float[3];

        for(int i=1; i<parcours.Count; i++){

            Transform table = parcours[i-1].transform;
            Transform tableSuivante = parcours[i].transform;

            Vector3 directionVersTableSuivante = table.position - tableSuivante.position;

            float angleForward = Vector3.Angle(table.forward, directionVersTableSuivante);
            float angleRight = Vector3.Angle(table.right , directionVersTableSuivante);
            float angleUp = Vector3.Angle(table.up , directionVersTableSuivante);

            if(i==1){
                angleInit = new float[] {angleForward, angleRight, angleUp};
            }
                
            if (Math.Abs(angleInit[0] - angleForward) > 50 || Math.Abs(angleInit[1] - angleRight) > 50 || Math.Abs(angleInit[2] - angleUp) > 50 ){
                sequencesPrevu.Add("t");
                sequencesPrevu.Add("a");
                angleInit = new float[] {angleForward, angleRight, angleUp};
            } else if(Math.Abs(angleInit[2] - angleUp) > 25){
                sequencesPrevu.Add("s");
            }
            else {
                sequencesPrevu.Add("a");
            }
            
        }

        nbrMouvement = sequencesPrevu.Count;
        Debug.Log(String.Join("", sequencesPrevu.ToArray()));
 
    }

    public static int getNbrCoupMaximum(){
        return nbrMouvement;
    }

}
