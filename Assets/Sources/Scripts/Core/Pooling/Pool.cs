using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : IPool where T : PoolElement
{
    private Transform Container;
    private GameObject Prefab = null;
    private List<T> Elements = new List<T>();
    private bool IsLimited = false;

    public Pool(int count, GameObject prefab, bool isLimited = false, Transform localParent = null)
    {
        Elements.Clear();

        Prefab = prefab;
        Container = CreatePoolContainer(localParent, $"Container ({prefab.name})");
        Elements.AddRange(CreateElements(count));
        IsLimited = isLimited;
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
        var element = GameObject.Instantiate(Prefab, Container).GetComponent<T>();
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
        element.IsInPool = false;

        if (IsLimited)
        {
            Elements.Insert(Elements.Count - 1, element);
            Elements.RemoveAt(0);
        }

        return element;
    }

    public void ReturnToPool(PoolElement poolElement)
    {
        poolElement.transform.SetParent(Container);
        poolElement.gameObject.SetActive(false);
        poolElement.IsInPool = true;
    }

    private T Get()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i].IsInPool || IsLimited)
            {
                return Elements[i];
            }
        }

        return CreateElement();
    }
}