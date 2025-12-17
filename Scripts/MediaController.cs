using UnityEngine;

public class MediaController : MonoBehaviour
{
    public static MediaController Instance;
    


    [SerializeField] private VideoListController videoListController;

    private void Start()
    {
        LoadVideosFromJSON();
    }


    private void Awake()
    {
        Instance = this;
        
    }

    public void LoadVideosFromJSON()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("sample_videos");

        if (jsonFile == null)
        {
            videoListController.ShowNoVideos();
            return;
        }

        VideoListData data = JsonUtility.FromJson<VideoListData>(jsonFile.text);

        if (data == null || data.videos == null || data.videos.Count == 0)
        {
            videoListController.ShowNoVideos();
        }
        else
        {
            videoListController.PopulateVideos(data.videos);
        }
    }
}
