using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{

    [SerializeField] Text textPorcentagem;

    private void Start()
    {
        StartCoroutine(LoadScene_Estiloso());
    }


    private IEnumerator LoadScene_Estiloso()
    {

        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("loadingCena"));
        operation.allowSceneActivation = false;

        float progresso = 0.0f;

        textPorcentagem.DOText("CARREGANDO...", 10f, true);

        while (progresso < 100)
        {
            yield return new WaitForSeconds(.8f);

            progresso += 5.0f;

            

            
        }

        operation.allowSceneActivation = true;
        yield return null;


    }

}
