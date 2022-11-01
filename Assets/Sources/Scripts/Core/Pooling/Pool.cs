using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : IPool where T : PoolElement
{
    private Transform _container;
    private GameObject _prefab = null;
    private List<T> _elements = new List<T>();
    private bool _isLimited = false;

    public Pool(int count, GameObject prefab, bool isLimited = false, Transform localParent = null)
    {
        _elements.Clear();

        _prefab = prefab;
        _container = CreatePoolContainer(localParent, $"Container ({prefab.name})");
        _elements.AddRange(CreateElements(count));
        _isLimited = isLimited;
    }

    public Transform CreatePoolContainer(Transform containerParent, string name = "pool_container")
    {
        GameObject container = new GameObject(name);

        container.SetActive(false);
        container.transform.SetParent(containerParent);

        return container.transform;
    }

    private T CreateElement()
    {
        var element = GameObject.Instantiate(_prefab, _container).GetComponent<T>();
        element.InitPoolElement(this);
        ReturnToPool(element);
        return element;
    }

    private List<T> CreateElements(int count)
    {
        List<T> elements = new List<T>();
        for (int i = 0; i < count; i++)
        {
            elements.Add(CreateElement());
        }
        return elements;
    }

    public T Get(Transform newParent = null)
    {
        var element = Get();
        element.transform.SetParent(newParent, false);
        element.gameObject.SetActive(true);
        element.isInPool = false;

        if (_isLimited)
        {
            _elements.Insert(_elements.Count - 1, element);
            _elements.RemoveAt(0);
        }

        return element;
    }

    public void ReturnToPool(PoolElement poolElement)
    {
        poolElement.transform.SetParent(_container);
        poolElement.gameObject.SetActive(false);
        poolElement.isInPool = true;
    }

    private T Get()
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].isInPool || _isLimited)
            {
                return _elements[i];
            }
        }

        return CreateElement();
    }
}