using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
    public Color GlowColor;
    public float LerpFactor = 10;
    public bool glowing;

    public float timer = 0;
    float waitTime = 0.15f;

    public Renderer[] Renderers
    {
        get;
        private set;
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
    }

    private List<Material> _materials = new List<Material>();
    private Color _currentColor;
    private Color _targetColor;

    void Start()
    {
        glowing = false;

        Renderers = GetComponentsInChildren<Renderer>();

        foreach (var renderer in Renderers)
        {
            _materials.AddRange(renderer.materials);
        }
    }

    public void OnGlowEnter()
    {
        _targetColor = GlowColor;
        enabled = true;
        glowing = true;
    }

    public void OnGlowExit()
    {
        _targetColor = Color.black;
        enabled = true;
        glowing = false;
    }

    private void OnDisable()
    {
        OnGlowExit();
    }

    /// <summary>
    /// Loop over all cached materials and update their color, disable self if we reach our target color.
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime; //Timer to keep track of how long the object has been in the scene
        if (timer >= waitTime)//if the timer is greater than the wait time
        {
            OnGlowExit();//Stop glowing
            timer = 0.0f;//Set the timer back to 0
        }
        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetColor("_GlowColor", _currentColor);//Set the glow color
        }

        if (_currentColor.Equals(_targetColor))
        {
            enabled = false;
        }

    }
}
