using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuPrincipalManager : MonoBehaviour
{

    [SerializeField] AudioAmbient _audioAb;

    [SerializeField] private string nomedoleveldejogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
   

    //animacao hud
    [SerializeField] List<Transform> _butaoMenu;


    private void Awake()
    {
       // _audioAb = FindAnyObjectByType<AudioAmbient>();
       // _audioAb._ativaDestruicao = true;
    }

    private void Start()
    {
        //Jotap�
        for (int i = 0; i < _butaoMenu.Count; i++)
        {
            _butaoMenu[i].localScale = new Vector3(0, 0, 0);
        }
        StartCoroutine(TempoScale());

    }
   

    public void AbrirOpcoes()
    {
        
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void fecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sairjogo()
    {
        PlayerPrefs.DeleteKey("loadingCena");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void ChamaJogo()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("loadingCena");
        SceneManager.LoadScene("Introducao");
        PlayerPrefs.DeleteKey("SalvaPaginaScore");
    }

    public void ChamaContinue()
    {
        PlayerPrefs.DeleteKey("loadingCena");
        SceneManager.LoadSceneAsync("Mapa");
    }

    IEnumerator TempoScale() //Jotape
    {
        yield return new WaitForSeconds(.25f);
        for (int i = 0; i < _butaoMenu.Count; i++)
        {
            _butaoMenu[i].DOScale(new Vector3(1f, 1f, 1f), 1f);
            yield return new WaitForSeconds(.25f);
        }
    }



}
