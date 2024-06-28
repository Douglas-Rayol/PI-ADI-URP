using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamaMap : MonoBehaviour
{
    [SerializeField] GameObject _particula;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Portal());
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
        yield return new WaitForSeconds(1f);
        ChamaMapa();
    }
}
