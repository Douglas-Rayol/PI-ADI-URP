using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Mordida : MonoBehaviour
{
    [SerializeField] Animator _animInimigo;
    [SerializeField] Transform _position;
    [SerializeField] Transform _position2;
    [SerializeField] Transform _player;

    public void PlantaAnimacao()
    {
        StartCoroutine(TempoMordida());
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TempoMordida());
        }
    }

    IEnumerator TempoMordida()
    {
        _player.GetComponent<PlayerController>()._ativadorMovimento = false;
        _animInimigo.SetBool("fechada", true);
        _animInimigo.SetBool("aberta", false);
        _player.DOMove(new Vector3(_position.position.x, _player.position.y, _player.position.z), .5f);
        yield return new WaitForSeconds(1f);
        _player.DOMove(new Vector3(_position2.position.x, _player.position.y, _player.position.z), .0f);
        _animInimigo.SetBool("aberta", true);
        _animInimigo.SetBool("fechada", false);
        _player.GetComponent<PlayerController>()._ativadorMovimento = true;
    }






}
