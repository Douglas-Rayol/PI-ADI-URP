using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBatalha : MonoBehaviour
{
    [SerializeField] GameObject[] _menu;
    [SerializeField] Button _butaoReiniciar, _butaoMenu;
    [SerializeField] public TextMeshProUGUI _playerVenceu;
    [SerializeField] TiroPadrao _tiroPadrao; //Quando reiniciar o jogo, o dano do tiro volta pro dano padrao
    [SerializeField] public bool _startMenu;

    void Update()
    {
        //Aqui ver quem foi que ganhou
        if(PlayerPrefs.GetInt("Player") == 1)
        {
            _playerVenceu.text = "Player 2 Venceu!";
        }
        else if(PlayerPrefs.GetInt("Player") == 2)
        {
            _playerVenceu.text = "Player 1 Venceu!";
        }
        
    }

    public IEnumerator AtivaMenu(int _tempo)
    {
        _tiroPadrao._dano = 2; //Quando reiniciar o jogo, o dano do tiro volta pro dano padrao

        _butaoReiniciar.enabled = true;
        _butaoMenu.enabled = true;

        yield  return new WaitForSeconds(_tempo);

        for (int i = 0; i < _menu.Length; i++)
        {
            _menu[i].transform.DOScale(.6f, .3f);
        }
        yield  return new WaitForSeconds(.3f);

        for (int i = 0; i < _menu.Length; i++)
        {
            _menu[i].transform.DOScale(.6f, .3f);
        }

        _butaoReiniciar.Select();

        GetComponent<BatalhaControle>()._pausaJogo = true;

        yield return new WaitForSeconds(.3f);


        
    }

    public IEnumerator DesativaMenu()
    {
        _butaoReiniciar.enabled = false;
        _butaoMenu.enabled = false;

        for (int i = 0; i < _menu.Length; i++)
        {
            _menu[i].transform.DOScale(0f, .3f);
        }

        yield  return new WaitForSeconds(.3f);

        _butaoReiniciar.Select();

        GetComponent<BatalhaControle>()._pausaJogo = false;

        

    }

    public void ChamaMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void ChamaReiniciar()
    {
        SceneManager.LoadScene("Batalha");
        //PlayerPrefs.DeleteKey("Player");
    }

}
