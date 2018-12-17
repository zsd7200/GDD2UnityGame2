using UnityEngine;
using System.Collections.Generic;

public class AlwaysGlow : MonoBehaviour
{
    public Color GlowColor;
    public bool glow;

    public Renderer[] Renderers
    {
        get;
        private set;
    }

    private List<Material> _materials = new List<Material>();
    private Color _targetColor;

    void Start()
    {
        glow = false;
        Renderers = GetComponentsInChildren<Renderer>();

        foreach (var renderer in Renderers)
        {
            _materials.AddRange(renderer.materials);
        }

        _targetColor = GlowColor;

    }

    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>
    private void Update()
    {
        if (glow == true)
        {
            for (int i = 0; i < _materials.Count; i++)
            {
                _materials[i].SetColor("_GlowColor", _targetColor);//Set the glow color
            }
        }
    }
}
