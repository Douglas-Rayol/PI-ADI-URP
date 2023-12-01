using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{
    [SerializeField] ControlaPlayerTest _velocidadePlayer;
    [SerializeField] AudioSource _somHit;

    public bool ativaMorte = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider death)
    {
        if(death.gameObject.CompareTag("InimigoPlat"))
        {
            StartCoroutine(TempoReinicia());
        }

        if(death.gameObject.CompareTag("Inimigo") && ativaMorte == false)
        {
            StartCoroutine(TempoDeMorte());
        }

        if(death.gameObject.CompareTag("InimigoObst") && ativaMorte == false)
        {
            StartCoroutine(TempoDeMorte());
        }

        IEnumerator TempoDeMorte()
        {
            ativaMorte = true;
            _somHit.Play();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Run");
        }

        IEnumerator TempoReinicia()
        {
            _velocidadePlayer._speed = 0f;
            yield return new WaitForSeconds(0.25f);
            SceneManager.LoadScene("Run");
        }

    }


}
