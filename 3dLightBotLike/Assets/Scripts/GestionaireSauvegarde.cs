using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sauvegarde {
    public List<int> niveau;
    public List<int> débloqué;
    public int position;

    public Sauvegarde (List<int> unNomNiveau, List<int> unDébloqué, int unePosition) {
        niveau = unNomNiveau;
        débloqué = unDébloqué;
        position = unePosition;
    }

}

public class GestionaireSauvegardes {

    private static Sauvegarde Charger(string nomFichier) {
        string json;
        using(StreamReader reader = new StreamReader(nomFichier)) {
	           json = reader.ReadToEnd();
		}

		return JsonUtility.FromJson<Sauvegarde>(json);
    }

    public static Sauvegarde Charger(){
		Sauvegarde sauvegarde;
		if(System.IO.File.Exists("sauvegarde.json")){
			Debug.Log("sauvegarde existe");
			sauvegarde = Charger("sauvegarde.json");
		} else {
			Debug.Log("sauvegarde n'existe pas");
			sauvegarde = new Sauvegarde(new List<int>(){0},new List<int>(){1}, 1);
		}

		return sauvegarde;
	}

	public static void Sauvegarder(Sauvegarde sauvegarde){
		Sauvegarder(sauvegarde, "sauvegarde.json");
	}

    private static void Sauvegarder(Sauvegarde sauvegarde, string nom_de_fichier){
		using(StreamWriter writer = new StreamWriter(nom_de_fichier)){
			writer.Write(JsonUtility.ToJson(sauvegarde));
		}
	}

}
