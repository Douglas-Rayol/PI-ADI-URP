using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Personagemcolisao : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private GameObject transicaoGameOver;
    [SerializeField] private GameObject painelGameOver;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "limite")
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("player");
       
        transicaoGameOver.transform.position = transform.position;
        transicaoGameOver.SetActive(true);

        StartCoroutine(ExibirPainelGameOver());
    }

    private IEnumerator ExibirPainelGameOver()
    {
        yield return new WaitForSecondsRealtime(1f);
        painelGameOver.SetActive(true);

    }
}
