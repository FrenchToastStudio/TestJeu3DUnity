using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{

    [SerializeField]
    private float uniteDeplacement = 1f;
    [SerializeField]
    private float hauteurSaut = 4.5f;
    [SerializeField]
    private float uniteDeplacementSaut = 1.30f;
    [SerializeField]
    private Animator animateur;

    [SerializeField]
    private GameObject UIgameplay;

    [SerializeField]
    private GameObject textPerdu;

    private float rotation;
    private float rotationGauche = -90.0f;
    private float rotationDroite = 90.0f;

    private Vector3 positionDebutNiveau;
    private Vector3 positionDepart;
    private Vector3 destination;

    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    bool enMouvement = false;
    bool go = false;
    bool marche = false;
    bool saute = false;
    bool peutLancerSéquence = true;

    private List<String> sequence = new List<string>();

    private List<String> historiqueSequence;

    private GameObject[] listBtnSequence;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        // Pour initialiser un restart
        positionDebutNiveau = transform.position;
        destination = transform.position + (transform.forward);

    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.y < 0){
            animateur.SetBool("saute", false);
        }


        if(transform.position.z == destination.z && transform.position.x == destination.x){
            Debug.Log("arrive");
            Debug.Log(transform.position.z + " " + destination.z);
            animateur.SetBool("marche", false);
            marche = false;
            enMouvement = false;
        }

        if(!enMouvement && sequence.Count > 0 && go){
            Debug.Log("inside if - commande : " + sequence[0]);
            positionDepart = transform.position;
            enMouvement = true;
            switch(sequence[0]){
                case "Avance":
                    destination = transform.position + (transform.forward);
                    marche = true;
                    break;
                case "Saut":
                    saut();
                    saute = true;
                    break;
                case "Gauche":
                    tourne(rotationGauche);
                    getPositionPersonnage();
                    enMouvement = false;
                    break;
                case "Droite":
                    tourne(rotationDroite);
                    getPositionPersonnage();
                    enMouvement = false;
                    break;
            }
            sequence.RemoveAt(0);
        }


        //Gestion du déplacement vers l'avant
        if(Input.GetKeyDown(KeyCode.W)){
            destination = transform.position + (transform.forward);
            marche = true;
        }else if(Input.GetKeyDown(KeyCode.X)){

            animateur.SetBool("saute", true);
            animateur.SetBool("estAuSol", false);
            rigidbody.AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
            rigidbody.AddForce(transform.forward * uniteDeplacementSaut, ForceMode.Impulse);

        }else if(Input.GetKeyDown(KeyCode.A))
            transform.Rotate(Vector3.up, rotationGauche);
        else if(Input.GetKeyDown(KeyCode.D))
            transform.Rotate(Vector3.up, rotationDroite);

        if (marche){
            animateur.SetBool("marche", true);
            transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision collision){
        Debug.Log(saute);
        animateur.SetBool("estAuSol", true);
        if(saute){
            enMouvement = false;
            saute = false;
            Debug.Log("est au sol - mouvement false");
        }
        if(collision.gameObject.tag == "sol"){
            Time.timeScale = 0;
            DisplayMessage(textPerdu);
        }
    }

    void DisplayMessage(GameObject unGameobject){
        GameObject message = Instantiate(unGameobject) as GameObject;
        message.transform.SetParent(UIgameplay.transform, false);
        message.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,0);
        message.GetComponent<RectTransform>().localScale = new Vector3(4,5,1);
    }

    public void getPositionPersonnage(){
        positionDepart = transform.position;
    }

    public void LancerSequence(){
        if(peutLancerSéquence){
            if(sequence.Count == 0 && historiqueSequence.Count > 0)
                sequence = copyList(historiqueSequence);
            historiqueSequence = copyList(sequence);
            go =true;
        }
    }

    public void recommencerNiveau(){
        transform.position = positionDebutNiveau;
        sequence = historiqueSequence = new List<string>();
        listBtnSequence = GameObject.FindGameObjectsWithTag("btnSequence");
        foreach(GameObject unBtn in listBtnSequence){
            Destroy(unBtn);
        }
    }

    public void setMouvementGauche(){
        sequence.Add("Gauche");
    }

    public void setMouvementAvance(){
        sequence.Add("Avance");
    }

    public void setMouvementDroite(){
        sequence.Add("Droite");
    }

    public void setMouvementSaut(){
        sequence.Add("Saut");
    }

    public void saut(){
        animateur.SetBool("saute", true);
        animateur.SetBool("estAuSol", false);
        GetComponent<Rigidbody>().AddForce(Vector3.up * hauteurSaut, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * uniteDeplacement, ForceMode.Impulse);
    }

    public void tourne (float rotation){
        transform.Rotate(Vector3.up, rotation);
    }

    private List<String> copyList (List<String> listeOriginale){
        List<String> listeDestination = new List<string>();
        foreach(String valeur in listeOriginale){
            listeDestination.Add(valeur);
        }
        return listeDestination;
    }
}
