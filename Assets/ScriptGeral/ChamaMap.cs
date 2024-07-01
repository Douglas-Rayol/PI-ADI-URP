using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChamaMap : MonoBehaviour
{
    [SerializeField] GameObject _particula;
    [SerializeField] GameObject _placaLevel;
    GameControle _gamecontrole;

    // Start is called before the first frame update
    void Start()
    {
        _gamecontrole = Camera.main.GetComponent<GameControle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(_gamecontrole._playerController._checkGround == false)
            {
                _gamecontrole._playerController._rb.isKinematic = true;
                _gamecontrole._playerController.transform.DOScale(0f, 1f);
                Invoke("JumpAr", 1f);
            }
            else
            {
             
             StartCoroutine(Portal());

            }

        }
    }

    public void ChamaMapa()
    {
        SceneManager.LoadScene("Mapa");
    }

    IEnumerator Portal()
    {
        yield return new WaitForSeconds(.25f);
        _particula.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _gamecontrole._playerController._rb.velocity = new Vector3(_gamecontrole._playerController._rb.velocity.x, _gamecontrole._playerController._jump, _gamecontrole._playerController._rb.velocity.z);
        yield return new WaitForSeconds(1.15f);
        _gamecontrole._playerController._rb.isKinematic = true;
        _gamecontrole._playerController.transform.DOScale(0f, 1f);
        yield return new WaitForSeconds(1f);
        JumpAr();
    }
    public void JumpAr()
    {
        _placaLevel.SetActive(true);
    }
}
