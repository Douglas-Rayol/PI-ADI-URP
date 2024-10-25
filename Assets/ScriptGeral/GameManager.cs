using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("Hud Vida do Jogador")]
    public PlayerController _vidaJogador;
    [SerializeField] GameObject[] _hudVida;
    [SerializeField] GameObject[] _hudVidaVazia;
    [SerializeField] GameObject[] _hudDef;


    [Header("Pause do Jogo")]
    [SerializeField] public bool _pause;

    bool _CheckStartesc;
    bool _iniCheck;

    // Start is called before the first frame update
    void Start()
    {
        _vidaJogador = FindObjectOfType<PlayerController>();
        StartCoroutine(StartHud());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_vidaJogador != null)
        {


            if (_iniCheck)
            {
                VidaDoJogadorHud();
            }



            if (_vidaJogador._ativaDefesa == true)
            {
                DefesaDoJogadorHud();
                if (!_CheckStartesc)
                {
                    _CheckStartesc = true;
                    StartCoroutine(StarEscud());
                }

            }
        }


        ////S� para reiniciar o jogo. Futuramente Tiramos;
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SceneManager.LoadScene("Ato_1_1");
        //}


    }

    public IEnumerator StartHud()
    {
        for (int i = 0; i < _hudVida.Length; i++)
        {
            _hudVida[i].transform.localScale = Vector3.zero;
            _hudVidaVazia[i].transform.localScale = Vector3.zero;
        }

        yield return new WaitForSeconds(0.25f);


        for (int i = 0; i < _hudVida.Length; i++)
        {
            _hudVidaVazia[i].transform.DOScale(8f, .25f);
            _hudVida[i].transform.DOScale(8f, .25f);
            yield return new WaitForSeconds(0.25f);
            _hudVidaVazia[i].transform.DOScale(6f, .25f);
            _hudVida[i].transform.DOScale(5f, .25f);
          
        }
        _iniCheck = true;
    }

    public IEnumerator StarEscud()
    {
        for (int i = 0; i < _hudDef.Length; i++)
        {
            _hudDef[i].transform.localScale = Vector3.zero;
           // _hudVidaVazia[i].transform.localScale = Vector3.zero;
        }

        yield return new WaitForSeconds(0.25f);


        for (int i = 0; i < _hudDef.Length; i++)
        {
            _hudDef[i].transform.DOScale(8f, .25f);
            yield return new WaitForSeconds(0.25f);
            _hudDef[i].transform.DOScale(5f, .25f);
        }
    }


    public IEnumerator pausaTime()
    {
        yield return new WaitForSeconds(1.38f);
        _pause = false;
    }



    void VidaDoJogadorHud()
    {

        if(_vidaJogador._vida == 3)
        {
            _hudVida[2].transform.DOScale(5f, .25f);
            _hudVida[1].transform.DOScale(5f, .25f);
            _hudVida[0].transform.DOScale(5f, .25f);
        }

        if (_vidaJogador._vida == 2)
        {
            _hudVida[2].transform.DOScale(0f, .25f);
        }

        if (_vidaJogador._vida == 1)
        {
            _hudVida[1].transform.DOScale(0f, .25f);
        }

        if (_vidaJogador._vida == 0)
        {
            _hudVida[0].transform.DOScale(0f, .25f);
        }

    }

    void DefesaDoJogadorHud()
    {
        if (_vidaJogador._defesaUp == 3)
        {
            _hudDef[2].transform.DOScale(5f, .25f);
            _hudDef[1].transform.DOScale(5f, .25f);
            _hudDef[0].transform.DOScale(5f, .25f);
        }

        if (_vidaJogador._defesaUp == 2)
        {
            _hudDef[2].transform.DOScale(0f, .25f);
        }

        if (_vidaJogador._defesaUp == 1)
        {
            _hudDef[1].transform.DOScale(0f, .25f);
        }

        if (_vidaJogador._defesaUp == 0)
        {
            _hudDef[0].transform.DOScale(0f, .25f);
        }
    }
}
