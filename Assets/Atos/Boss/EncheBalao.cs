using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EncheBalao : MonoBehaviour{

    public GameObject _balao; // O objeto que vai aumentar de tamanho
    public Vector3 _crescimento = new Vector3(1f, 1f, 1f); // Fator de crescimento
    private int _contaPulos = 0;
    public int maxJumps = 4; // Número máximo de vezes que o objeto pode crescer
    public Vector3 _tamanhoInicial; // Variável para armazenar o tamanho inicial do objeto
     public float _enchendoBalao = 0.5f; // Duração da animação de crescimento


    void OnCollisionEnter(Collision collision){
     // Verifica se o jogador colidiu com o objeto
        if (collision.gameObject.tag == "Player"){
            // Verifica se o número de pulos ainda não atingiu o máximo
            if (_contaPulos < maxJumps){
                // Aumenta o tamanho do objeto alvo com animação usando DOTween
                Vector3 newScale = _balao.transform.localScale + _crescimento;
                _balao.transform.DOScale(newScale, _enchendoBalao);

                // Incrementa o contador de saltos
                _contaPulos++;
        }   else{
                    _contaPulos = 0;

                    _balao.transform.localScale = _tamanhoInicial;
                }
            }
    }
 
}
