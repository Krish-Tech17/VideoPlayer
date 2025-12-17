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
                item.gameObject.SetActive(true);
                return item;
            }
        }

        // Nothing available → create new
        var newItem = Instantiate(prefab, parent);
        newItem.transform.localScale = Vector3.one;
        pool.Add(newItem);
        return newItem;
    }

    public void ReturnAllObjects()
    {
        foreach (var item in pool)
        {
            // stop video if needed
            //item.StopVideoIfPlaying?.Invoke();

            item.gameObject.SetActive(false);
        }
    }

    public List<VideoItemUI> GetPool()
    {
        return pool;
    }
}