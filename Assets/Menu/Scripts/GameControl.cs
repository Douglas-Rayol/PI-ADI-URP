using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<AudioSource> _audioHud;
    public List<AudioSource> _somMusic;
    public List<AudioSource> _somGame;
    public bool _muteHud;
    public bool _muteMusic;
    public bool _muteGame;
    public bool _startGame;
    public Transform _paginas;
   
    public void GamePlayer()
    {
        //_startGame = true;
    }

    void Update()
    {
        for (int i = 0; i < _audioHud.Count; i++)
        {
            _audioHud[i].mute = _muteHud;
        }
        for (int i = 0; i < _somMusic.Count; i++)
        {
            _somMusic[i].mute = _muteMusic;
        }
        for (int i = 0; i < _somGame.Count; i++)
        {
            _somGame[i].mute = _muteGame;
        }
    }
}
