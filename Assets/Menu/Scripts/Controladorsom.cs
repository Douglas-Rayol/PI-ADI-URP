using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controladorsom : MonoBehaviour
{
    public bool _somHud;
    public bool _somMusic;
    public bool _somGame;
    public GameControl _gameControl;
    public AudioSource _audioSource;

    void Start()
    {
        _gameControl = Camera.main.GetComponent<GameControl>();
        _audioSource = GetComponent<AudioSource>();
        if (_somHud)
        {
            _gameControl._audioHud.Add(_audioSource);
        }
        else if (_somMusic)
        {
            _gameControl._somMusic.Add(_audioSource);
        }
        else if (_somGame)
        {
            _gameControl._somGame.Add(_audioSource);
        }
    }


    void Update()
    {

    }
}
