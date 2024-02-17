using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class ObjectPooler
{
    public static Dictionary<string, Component> poolLookup = new Dictionary<string, Component>();   
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();

    public static void EnqueuObject<T>(T item, string name) where T : Component {
        if (!item.gameObject.activeSelf) { return; }

        item.transform.position = Vector2.zero;
        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public static T DequeuObject<T>(string key) where T : Component
    {
        if (poolDictionary[key].TryDequeue(out var item))
        {
            return (T)item;
        }
        return (T)EnqueNewInstance(poolLookup[key], key);

        //return (T)poolDictionary[key].Dequeue();
    }

    public static T EnqueNewInstance<T>(T item, string key) where T : Component
    {
        T newInstance = Object.Instantiate(item);
        newInstance.gameObject.SetActive(false);
        newInstance.transform.position = Vector2.zero;
        poolDictionary[key].Enqueue(newInstance);
        return newInstance;
    }

    public static void SetupPool<T>(T pooledItemPrefab, int poolSize, string dictionaryEntry) where T : Component
    {
        poolDictionary.Add(dictionaryEntry, new Queue<Component>());

        poolLookup.Add(dictionaryEntry, pooledItemPrefab);

        for (int i = 0;  i < poolSize; i++)
        {
            T pooledInstance = Object.Instantiate(pooledItemPrefab);
            pooledInstance.gameObject.SetActive(false);
            poolDictionary[dictionaryEntry].Enqueue((T)pooledInstance);
        }
    }
}
