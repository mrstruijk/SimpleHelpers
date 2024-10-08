using System;
using UnityEngine;


public class TaggedRenderersToggler : MonoBehaviour
{
    [SerializeField] private string m_tag;
    [SerializeField] private bool m_startDisabled;

    private Renderer[] _renderers = Array.Empty<Renderer>();
    private GameObject _taggedObject;


    private void FindTaggedObject()
    {
        _taggedObject = GameObject.FindGameObjectWithTag(m_tag);

        if (_taggedObject == null)
        {
            Debug.Log("No object with tag " + m_tag + " found.");

            return;
        }

        _renderers = _taggedObject.GetComponentsInChildren<Renderer>();
    }


    public void ToggleRenderers(bool enable)
    {
        FindTaggedObject();

        if (_renderers == null || _renderers.Length == 0)
        {
            Debug.Log("No renderers found on object with tag " + m_tag);

            return;
        }

        foreach (var rend in _renderers)
        {
            rend.enabled = enable;
        }
    }
}