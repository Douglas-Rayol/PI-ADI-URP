using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SumirParede : MonoBehaviour{

    //tava com preguica, fiz com chat gpt msm

    public GameObject targetObject; // O objeto que ficará transparente
    public float transparencyAmount = 0.3f; // Nível de transparência (0 = totalmente transparente, 1 = opaco)
    public float fadeDuration = 1f; // Duração do fade

    private Material targetMaterial;
    private Color originalColor;

    void Start()
    {
        // Obtém o material do objeto alvo
        if (targetObject != null)
        {
            targetMaterial = targetObject.GetComponent<Renderer>().material;
            originalColor = targetMaterial.color;
            
            // Configura o material para ser transparente no URP
            SetMaterialToTransparent(targetMaterial);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador tocou no objeto
        if (other.CompareTag("Player"))
        {
            // Inicia o fade para tornar o objeto transparente usando DOTween
            targetMaterial.DOFade(transparencyAmount, fadeDuration);
        }
    }


    // Configura o material para ser transparente no URP
    void SetMaterialToTransparent(Material mat)
    {
        mat.SetFloat("_Surface", 1); // 1 = Transparent (URP)
        mat.SetFloat("_Blend", 0); // 0 = Alpha blending

        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);

        // Ativa palavras-chave necessárias para o material transparente no URP
        mat.EnableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        
        mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent; // Definir como transparente
    }
}





