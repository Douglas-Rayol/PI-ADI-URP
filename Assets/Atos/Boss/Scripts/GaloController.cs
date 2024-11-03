using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GaloController : MonoBehaviour

{
    public Transform _player; // Referência ao jogador
    public float _moveSpeed = 3.5f; // Velocidade de movimento do boss
    public float _distanciaAtaque = 2f; // Distância para atacar o jogador
    public float _jabCooldown = 1.5f; // Tempo entre ataques de jab
    public float _PunchCooldown = 2.5f; // Tempo entre ataques Punchs
    public float _superCooldown = 5f; // Tempo entre ataques de super soco
    public bool _vulneravel = false; // Determina se o boss pode ser atacado
    public float _afastar = 2f; // Força de empurrão ao Blocker

    private float _proximoJab;
    private float _proximoPunch;
    private float _proximoSuper;
    private Animator anim; // Referência ao Animator para as animações
    private Rigidbody _rb; // Referência ao Rigidbody para aplicar o empurrão

    public CapsuleCollider _cc;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _proximoJab = Time.time + _jabCooldown;
        _proximoPunch = Time.time + _PunchCooldown;
        _proximoSuper = Time.time + _superCooldown;
    }

    void Update()
    {
        float distanceTo_player = Vector3.Distance(transform.position, _player.position);

        // Movimenta-se em direção ao jogador se estiver fora do alcance de ataque
        if (distanceTo_player > _distanciaAtaque)
        {
            MoveTowardsPlayer(_cc);
        }
        else
        {
            // Caso esteja dentro do alcance, escolhe uma ação
            ChooseAction();
        }
    }

    void MoveTowardsPlayer(CapsuleCollider _cc)
    {
        // Ação de caminhar em direção ao jogador apenas no eixo X
        anim.SetBool("GaloAndar", true);

        // Calcula a nova posição do boss, mantendo o eixo Y e Z
        Vector3 targetPosition = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
       
    }

    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ao colidir com o jogador, apenas mantenha a posição do boss
            // Se necessário, você pode aplicar efeitos, mas aqui apenas ignoramos a rotação
            _rb.velocity = Vector3.zero; // Remove qualquer velocidade do boss
            _rb.angularVelocity = Vector3.zero; // Remove qualquer rotação do boss

        }
    }

    void ChooseAction()
    {
        // Define as animações de movimento como false
        anim.SetBool("GaloAndar", false);

        // Caso o boss não seja vulnerável, ele se Blocke de todos os ataques
        if (!_vulneravel)
        {
            Block();
            return;
        }

        // Determina qual ataque realizar baseado nos tempos de cooldown
        if (Time.time >= _proximoJab)
        {
            Jab();
            _proximoJab = Time.time + _jabCooldown;
        }
        else if (Time.time >= _proximoPunch)
        {
            Punch();
            _proximoPunch = Time.time + _PunchCooldown;
        }
        else if (Time.time >= _proximoSuper)
        {
            SuperSoco();
            _proximoSuper = Time.time + _superCooldown;
        }
    }

    void Block()
    {
        // Ativa animação de defesa
        anim.SetTrigger("Block");
        Debug.Log("Boss está Blockendo.");

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

    void Punch()
    {
        // Executa o ataque Punch
        anim.SetTrigger("Punch");
        Debug.Log("Boss lançou um Punch!");
        // Coloque aqui a lógica de dano do Punch
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
    }

   


}
