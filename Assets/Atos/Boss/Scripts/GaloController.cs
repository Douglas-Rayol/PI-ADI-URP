using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaloController : MonoBehaviour

{
    public Transform _player; // Referência ao jogador
    public float _moveSpeed = 3.5f; // Velocidade de movimento do boss
    public float _distanciaAtaque = 2f; // Distância para atacar o jogador
    public float _jabCooldown = 1.5f; // Tempo entre ataques de jab
    public float _diretoCooldown = 2.5f; // Tempo entre ataques diretos
    public float _superCooldown = 5f; // Tempo entre ataques de super soco
    public bool _vulneravel = false; // Determina se o boss pode ser atacado
    public float _afastar = 2f; // Força de empurrão ao defender

    private float _proximoJab;
    private float _proximoDireto;
    private float _proximoSuper;
    private Animator anim; // Referência ao Animator para as animações
    private Rigidbody _rb; // Referência ao Rigidbody para aplicar o empurrão

    void Start()
    {
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _proximoJab = Time.time + _jabCooldown;
        _proximoDireto = Time.time + _diretoCooldown;
        _proximoSuper = Time.time + _superCooldown;
    }

    void Update()
    {
        float distanceTo_player = Vector3.Distance(transform.position, _player.position);

        // Movimenta-se em direção ao jogador se estiver fora do alcance de ataque
        if (distanceTo_player > _distanciaAtaque)
        {
            MoveTowards_player();
        }
        else
        {
            // Caso esteja dentro do alcance, escolhe uma ação
            ChooseAction();
        }
    }

    void MoveTowards_player()
    {
        // Ação de caminhar em direção ao jogador
        anim.SetBool("Andar", true);
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }

    void ChooseAction()
    {
        // Define as animações de movimento como false
        anim.SetBool("Andar", false);
    }
        // Caso o boss não seja vulnerável, ele se defende de todos os ataques
        /*if (!_vulneravel)
        {
            Defend();
            return;
        }

        // Determina qual ataque realizar baseado nos tempos de cooldown
        if (Time.time >= _proximoJab)
        {
            Jab();
            _proximoJab = Time.time + _jabCooldown;
        }
        else if (Time.time >= _proximoDireto)
        {
            Direto();
            _proximoDireto = Time.time + _diretoCooldown;
        }
        else if (Time.time >= _proximoSuper)
        {
            SuperSoco();
            _proximoSuper = Time.time + _superCooldown;
        }
    }

    void Defend()
    {
        // Ativa animação de defesa
        anim.SetTrigger("Defend");
        Debug.Log("Boss está defendendo.");

        // Aplica um empurrão para trás
        Knockback();
    }

    void Knockback()
    {
        // Calcula a direção oposta ao jogador e aplica uma força de empurrão
        Vector3 knockbackDirection = (transform.position - _player.position).normalized;
        _rb.AddForce(knockbackDirection * _afastar, ForceMode.Impulse);
    }

    void Jab()
    {
        // Executa o ataque jab
        anim.SetTrigger("Jab");
        Debug.Log("Boss lançou um jab!");
        // Coloque aqui a lógica de dano do jab
    }

    void Direto()
    {
        // Executa o ataque direto
        anim.SetTrigger("Direto");
        Debug.Log("Boss lançou um direto!");
        // Coloque aqui a lógica de dano do direto
    }

    void SuperSoco()
    {
        // Executa o ataque super soco
        anim.SetTrigger("SuperSoco");
        Debug.Log("Boss lançou um super soco!");
        // Coloque aqui a lógica de dano do super soco
    }

    // Método para tornar o boss vulnerável ao jogador
    public void SetVulnerable(bool vulnerable)
    {
        _vulneravel = vulnerable;
    }*/
}
