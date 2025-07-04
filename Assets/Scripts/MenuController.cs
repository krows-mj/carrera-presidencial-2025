using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuController : MonoBehaviour
{
    [Serializable]
    private struct FichaCandidato
    {
        public string nombre;
        public Sprite candidato;
        public Sprite boletaCandidato;
    }

    [Header("MENUS PRINCIPALES")]
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuSeleccion;
    [SerializeField] private GameObject uiEnJuego;
    [Header("Fichas de candidatos")]
    [SerializeField] private GameObject panelSelection;
    [SerializeField] private int indexListaCandidatos;
    private Image imgcanditato_00;
    private TMP_Text nombcandidato;
    [SerializeField] private FichaCandidato[] ListaCandidatos;
    [Header("Otras variables e.e")]
    [SerializeField] private int indexCandidatos;
    [SerializeField] private GameObject PanelMensaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nombcandidato = panelSelection.transform.GetChild(0).GetComponent<TMP_Text>();
        imgcanditato_00 = panelSelection.transform.GetChild(1).GetComponent<Image>();
        indexCandidatos = 0;
    }

    // Update is called once per frame
    //void Update(){}
    public void SiguienteCandidato(int i)
    {
        if (indexCandidatos + 1 >= ListaCandidatos.Length)
        {
            indexCandidatos = 0;
        }
        else
        {
            indexCandidatos++;
        }
        ActualizarFicha();
    }
    public void AnteriorCandidato(int i)
    {
        if (indexCandidatos - 1 < 0)
        {
            indexCandidatos = ListaCandidatos.Length;
        }
        else
        {
            indexCandidatos--;
        }
        ActualizarFicha();
    }
    [ContextMenu("Actualizar Ficha")]
    public void ActualizarFicha()
    {
        nombcandidato.text = ListaCandidatos[indexCandidatos].nombre;
        imgcanditato_00.sprite = ListaCandidatos[indexCandidatos].candidato;
    }
}
