using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoListController : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private TextMeshProUGUI emptyMessage;
    [SerializeField] private VideoItemPool videoPool;

    public void PopulateVideos(List<VideoItemData> videos)
    {
        videoPool.ReturnAllObjects();
        emptyMessage.gameObject.SetActive(false);

        foreach (var video in videos)
        {
            VideoItemUI item = videoPool.GetObject();
            item.Setup(video);
        }
    }

    public void ShowNoVideos()
    {
        videoPool.ReturnAllObjects();
        emptyMessage.gameObject.SetActive(true);
        emptyMessage.text = "No Videos Available";
    }
}
