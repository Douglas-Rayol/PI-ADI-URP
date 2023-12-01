using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class ControlaPlayerTest : MonoBehaviour
{
    [SerializeField] AudioSource[] _sons;

    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _animPlayer;

    [SerializeField] Morte _MortePlayer;

    
    [SerializeField] public float _speed;
    [SerializeField] float _jumpForce;

    [SerializeField] bool checkChao = false;
    [SerializeField] bool jump = false;

    [SerializeField] float tempoInicia;

    [SerializeField] GameControl _gameControl;

    [SerializeField] public int _paginas = 0;



    //AudioDePassos


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
      //  _gameControl = Camera.main.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_MortePlayer.ativaMorte == false)
        {
            animacaoPlayer();
        }

        if (_MortePlayer.ativaMorte == true)
        {
            _animPlayer.Play("hitporco");
            _speed = 0;
        }
        

        tempoInicia += Time.deltaTime;
        if(tempoInicia >= 2 && _gameControl._startGame)
        {
            MovimentoPlayer();
        }


    }

    public void SetPula(InputAction.CallbackContext value)
    {
        
        if (checkChao == true)
        {
            _sons[0].Play();
            _rb.AddForce(0, _jumpForce * 500, 0);
            checkChao = false;
           
        }
    }


    void MovimentoPlayer()
    {
        if (checkChao == true)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, _speed);

        }
    }

    void animacaoPlayer()
    {

        if(tempoInicia > 2 && checkChao == true)
        {
            _animPlayer.Play("run");
        }

        if (tempoInicia < 2 && checkChao == true)
        {
            _animPlayer.Play("idle");
        }
        
        if(checkChao == false)
        {
            _animPlayer.Play("jump");
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            checkChao = true;

        }

        if (other.gameObject.CompareTag("Paginas"))
        {
            _sons[1].Play();
            _paginas += 1;
            other.gameObject.SetActive(false);

        }

    }



}

