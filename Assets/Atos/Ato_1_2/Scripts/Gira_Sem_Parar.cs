using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Gira_Sem_Parar : MonoBehaviour
{
    [SerializeField] BatalhaControle _batalhaControle;

    void Awake()
    {
        _batalhaControle = Camera.main.GetComponent<BatalhaControle>();
    }

    public float velocidadeRotacao = 20f;
       

    void Update()
    {
        if(!_batalhaControle._pausaJogo)
        {
            // Rotaciona o objeto no eixo Y continuamente
            transform.Rotate(0,0, velocidadeRotacao * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !_batalhaControle._pausaJogo) //Aqui retira a vida do jogador, destroi o escudo
        {
            other.gameObject.GetComponent<PlayerBatalha>()._vidaMin -= 20;
            other.gameObject.GetComponent<HudPowerUp>()._ativaTempoEscudo = false;

            GetComponent<CapsuleCollider>().enabled = false;
            Invoke("HabilitaCollider", 1f);

            if(other.gameObject.transform.eulerAngles.y == 90)
            {
                other.gameObject.GetComponent<PlayerBatalha>()._rb.DOMove(new Vector3(other.gameObject.GetComponent<PlayerBatalha>()._rb.position.x - 20, 0, 0), .3f, false);
            }
            else
            {
                other.gameObject.GetComponent<PlayerBatalha>()._rb.DOMove(new Vector3(other.gameObject.GetComponent<PlayerBatalha>()._rb.position.x + 20, 0, 0), .3f, false);
            }

        }
    }

    private void HabilitaCollider()
    {
        GetComponent<CapsuleCollider>().enabled = true;
    }

}
