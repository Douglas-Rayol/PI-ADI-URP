using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Hud Vida do Jogador")]
    [SerializeField] PlayerController _vidaJogador;
    [SerializeField] GameObject[] _hudVida;

    [Header("Coisas pro Futuro")]
    [SerializeField] int variavelNada;

    // Start is called before the first frame update
    void Start()
    {
        _vidaJogador = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        VidaDoJogadorHud();

        //Só para reiniciar o jogo. Futuramente Tiramos;
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Ato_1_1");
        }


    }

    void VidaDoJogadorHud()
    {
        if(_vidaJogador._vida == 2)
        {
            _hudVida[2].SetActive(false);
        }

        if(_vidaJogador._vida == 1)
        {
            _hudVida[1].SetActive(false);
        }

        if (_vidaJogador._vida == 0)
        {
            _hudVida[0].SetActive(false);
        }

    }


}
