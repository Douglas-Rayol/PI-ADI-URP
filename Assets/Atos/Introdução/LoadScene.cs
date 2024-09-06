using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{

    [SerializeField] Text textPorcentagem;

    [SerializeField] int index;

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

       

        while (progresso < 100)
        {
            yield return new WaitForSeconds(.8f);

            AnulaCorrotine();

            progresso += 5.0f;

        }

        operation.allowSceneActivation = true;
        yield return null;
 
    }

    private void AnulaCorrotine()
    {
        if(index < 1)
        {
            index++;

            StartCoroutine(LoadScene_Minusculo());

        }
    }

    private IEnumerator LoadScene_Minusculo()
    {
        textPorcentagem.DOText("CARREGANDO...", 7.5f, true);
        yield return new WaitForSeconds(4f);
        textPorcentagem.DOText("carregando...", 7.5f, true);
        yield return new WaitForSeconds(4f);
        yield return LoadScene_Minusculo();
    }

}
