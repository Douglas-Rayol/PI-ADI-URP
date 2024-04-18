using UnityEngine;

public class NuvemControl : MonoBehaviour
{
    private Renderer _ren;
    private Material _mat;
    private float _offset;

    [SerializeField] private float _aumentar;
    [SerializeField] private float _speed;
    void Start()
    {
        _ren = GetComponent<MeshRenderer>();
        _mat = _ren.material;
    }

    private void FixedUpdate()
    {
        _offset +=  _aumentar;
        _mat.SetTextureOffset("_MainTex", new Vector2((_offset * _speed) / 1000, 0)); 
    }
}
