using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacon : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] Transform _posIni;
    [SerializeField] int _checktime, _timeLimit, _timeCheck;
    [SerializeField] bool _checkMove;
    [SerializeField] GameControl _gameControl;

    [SerializeField] AudioSource _som;

    // Start is called before the first frame update
    void Awake()
    {
        _checktime = _timeLimit;
       // _gameControl = Camera.main.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkMove == false && _gameControl._startGame)
        transform.position -= new Vector3(0, 0, _speed) * Time.deltaTime;

    }

    void InimigoOn_1()
    {
        GameObject bullet = RespawInimigo.SharedInstance.GetPooledObject();
        if (bullet != null)
        { 
            bullet.transform.position = _posIni.position;
            bullet.SetActive(true);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fim-Bacon")
        {
            _checkMove = true;
            _timeCheck = Random.Range(3, _timeLimit);
            Invoke("voltarposi", _timeCheck);
        }
    }
    */
    void voltarposi()
    {
        _checkMove = false;
        transform.position = _posIni.position;
    }



}
