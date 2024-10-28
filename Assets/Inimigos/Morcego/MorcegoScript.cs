using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorcegoScript : MonoBehaviour
{
   [SerializeField] GameManager _gameManager;

    [SerializeField] float _velociMorcego;
    [SerializeField] Transform _direcaoMorcego;
    [SerializeField] float dist, distMin;
    [SerializeField] float distPlayer;
    [SerializeField] bool _posplayer;
    
    
    public Transform _alvo;
    Rigidbody _rbMorcego;

    void Start(){
        
        _gameManager = Camera.main.GetComponent<GameManager>();
       // _alvo = Camera.main.GetComponent<GameControle>()._playerController.transform;

        
    }

    void Update() {


        if(_gameManager._pause == false)
        {
            //calcula a distancia do player
            dist = Vector3.Distance(_alvo.position , transform.position);

            //calcula a distancia minima estabelecida antes de executar o codigo abaixo
            distMin = dist/1.5f;

            //checa a distancia minima do player para comecar a perseguir
            //if (dist < distPlayer && !_posplayer || distMin <= 30f){
            if (distMin <= 40f){ 
                
                //enquanto a distancia for menor que 'X' segue o player
                while(dist <= 70f) {

                    Voltar(_alvo);
                    _velociMorcego = 16.5f;
                    break;
                }
                
                
            //se a distancia for maior que 'X' para de seguir o player
            }else{
                _velociMorcego = 0;
               // Voltar(_direcaoMorcego);
            }
 
        }
    }

    //se move na direcao do player
    void Voltar(Transform value) {
        // transform.LookAt(value.position);
        //transform.Rotate(new Vector3(0, 0, 20), Space.Self);//correcting the original rotation
        transform.position = Vector2.MoveTowards(transform.position, value.position, _velociMorcego * Time.deltaTime);
        
    }
}




