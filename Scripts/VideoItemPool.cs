using System.Collections.Generic;
using UnityEngine;

public class VideoItemPool : MonoBehaviour
{
    [SerializeField] private VideoItemUI prefab;
    [SerializeField] private Transform parent;

    private readonly List<VideoItemUI> pool = new List<VideoItemUI>();

    public VideoItemUI GetObject()
    {
        // Try to reuse an inactive one
        foreach (var item in pool)
        {
            if (!item.gameObject.activeSelf)
            {
                Debug.Log($"[VideoItemPool] Reusing pooled item → {item.name}");
                item.gameObject.SetActive(true);
                return item;
            }
        }

        // Nothing available → create new
        var newItem = Instantiate(prefab, parent);
        newItem.transform.localScale = Vector3.one;
        pool.Add(newItem);

        Debug.Log($"[VideoItemPool] Created NEW pooled item → {newItem.name}. Total Count: {pool.Count}");
        return newItem;
    }

    public void ReturnAllObjects()
    {
        Debug.Log($"[VideoItemPool] Returning ALL items to pool. Count: {pool.Count}");

        foreach (var item in pool)
        {
            if (item.gameObject.activeSelf)
            {
                Debug.Log($"[VideoItemPool] Deactivating → {item.name}");
            }

            item.gameObject.SetActive(false);
        }
    }

    public List<VideoItemUI> GetPool()
    {
        Debug.Log($"[VideoItemPool] Pool Requested. Total items stored: {pool.Count}");
        return pool;
    }
}