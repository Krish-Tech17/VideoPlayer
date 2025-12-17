using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class VideoItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image thumbnailImage;
    [SerializeField] private Button playButton;

    private VideoItemData videoData;

    public void Setup(VideoItemData data)
    {
        StopAllCoroutines(); // stop old thumbnail loads
        thumbnailImage.sprite = null; // reset old image

        videoData = data;

        titleText.text = data.title;
        descriptionText.text = data.description;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() =>
        {
            VideoPlayerController.Instance.PlayVideo(data.url);
        });

        StartCoroutine(LoadThumbnail(data.thumbnailUrl));
    }

    public void StopVideo()
    {
        VideoPlayerController.Instance?.StopVideo();
    }

    public void StopVideoIfPlaying()
    {
        if (VideoPlayerController.Instance == null)
            return;

        VideoPlayerController.Instance.StopVideo();
    }

    private IEnumerator LoadThumbnail(string relativePath)
    {
        // Build full local path from StreamingAssets
        string fullPath = $"file://{Application.streamingAssetsPath}/{relativePath}";

        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(fullPath))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Thumbnail load failed ({relativePath}): {request.error}");
                yield break;
            }

            Texture2D tex = DownloadHandlerTexture.GetContent(request);
            Sprite sprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f)
            );

            thumbnailImage.sprite = sprite;
        }
    }



}