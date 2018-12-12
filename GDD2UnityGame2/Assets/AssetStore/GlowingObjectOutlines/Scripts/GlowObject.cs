using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;

    public RaycastHit hit;

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
	}

	public void OnGlowExit()
	{
		_targetColor = Color.black;
		enabled = true;
    }

	/// <summary>
	/// Loop over all cached materials and update their color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
        //ray check objects hit for GlowObject
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3((Screen.width / 2), (Screen.height / 2), 0));
        //
        //if (Physics.Raycast(ray, out hit, 10))
        //{   
        //    GlowObject getGlow = null;
        //    getGlow = hit.transform.GetComponent<GlowObject>();
        //    if (getGlow != null)
        //    {
        //        OnGlowEnter();
        //    }
        //    else
        //    {
        //        OnGlowExit();
        //    }
        //}

        _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		for (int i = 0; i < _materials.Count; i++)
		{
			_materials[i].SetColor("_GlowColor", _currentColor);
		}

		if (_currentColor.Equals(_targetColor))
		{
			enabled = false;
		}
	}
}
