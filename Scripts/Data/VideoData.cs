using System;
using System.Collections.Generic;

[Serializable]
public class VideoItemData
{
    public string title;
    public string description;
    public string url;
    public string thumbnailUrl;
}

[Serializable]
public class VideoListData
{
    public List<VideoItemData> videos;
}
