using UnityEngine;
using System;

public class SelectedCandidateController : MonoBehaviour
{
    [SerializeField] private GameObject CardSelected;
    //[SerializeField] private GameObject Contend; //Contenido
    [Header("Lista de candidatos")]
    [Tooltip("Esta variable no se usa, es solo para que el encabezado funcione")] public int indexCandidate; //Esta variable no sirve, es solo para que el header funcione
/** Posibilidades xd 
    [System.Serializable]
    private struct ListCandidate
    {
        [SerializeField] private string idCandidate;
        [SerializeField] private bool enabledCandidate;
    }
    [SerializeField] private ListCandidate[] ListOfCandidate;
*/
    [SerializeField] private GameObject[] CardsCandidates;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    //void Update(){}

    public void SelectedCandidate(GameObject obj)
    {
        string n = obj.GetComponent<CardController>().getNameCandidate();
        CardSelected = obj;
        for (int i = 0; i < CardsCandidates.Length; i++)
        {
            if (n != CardsCandidates[i].GetComponent<CardController>().getNameCandidate())
            {
                CardsCandidates[i].GetComponent<CardController>().DeactiveSelectedCandidate();
            }
        }
        
    }
}
