using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerController : MonoBehaviour
{
    public static VideoPlayerController Instance;

    [Header("References")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Slider seekSlider;
    [SerializeField] private GameObject panel;

    private RectTransform panelRect;
    private bool isDragging;
    private bool isFullscreen;
    private bool isMinimized;

    // Stored values
    private Vector2 originalSize;
    private Vector2 originalAnchorMin;
    private Vector2 originalAnchorMax;
    private Vector2 originalOffsetMin;
    private Vector2 originalOffsetMax;

    [Header("Play / Pause UI")]
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Image playPauseIcon;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);

        panelRect = panel.GetComponent<RectTransform>();

        // Store original layout
        originalSize = panelRect.sizeDelta;
        originalAnchorMin = panelRect.anchorMin;
        originalAnchorMax = panelRect.anchorMax;
        originalOffsetMin = panelRect.offsetMin;
        originalOffsetMax = panelRect.offsetMax;

        videoPlayer.loopPointReached += OnVideoFinished;

    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        UpdatePlayPauseIcon();
    }


    private void Update()
    {
        if (videoPlayer.isPlaying && !isDragging && videoPlayer.length > 0)
        {
            seekSlider.value = (float)(videoPlayer.time / videoPlayer.length);
        }
    }

    public void PlayVideo(string url)
    {
        panel.SetActive(true);
        ResetLayout();

        videoPlayer.url = url;
        videoPlayer.Play();
        UpdatePlayPauseIcon();

    }

    public void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
        UpdatePlayPauseIcon();
    }

    private void UpdatePlayPauseIcon()
    {
        if (videoPlayer.isPlaying)
            playPauseIcon.sprite = pauseSprite;
        else
            playPauseIcon.sprite = playSprite;
    }


    // -------- SEEK ----------
    public void OnSeekStart()
    {
        isDragging = true;
    }

    public void OnSeekEnd()
    {
        if (videoPlayer.length > 0)
        {
            videoPlayer.time = seekSlider.value * videoPlayer.length;
        }
        isDragging = false;
    }

    // -------- FULLSCREEN ----------
    public void ToggleFullscreen()
    {
        if (isFullscreen)
        {
            RestoreOriginalLayout();
        }
        else
        {
            SetFullscreen();
        }

        isFullscreen = !isFullscreen;
        isMinimized = false;
    }

    private void SetFullscreen()
    {
        panelRect.anchorMin = Vector2.zero;
        panelRect.anchorMax = Vector2.one;
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;
    }

    // -------- MINIMIZE ----------
    public void Minimize()
    {
        if (isMinimized)
        {
            RestoreOriginalLayout();
            isMinimized = false;
            return;
        }

        panelRect.anchorMin = new Vector2(0.65f, 0.05f);
        panelRect.anchorMax = new Vector2(0.98f, 0.35f);
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;

        isMinimized = true;
        isFullscreen = false;
    }

    // -------- CLOSE ----------
    public void Close()
    {
        videoPlayer.Stop();
        panel.SetActive(false);

        UpdatePlayPauseIcon();

        RestoreOriginalLayout();
        isFullscreen = false;
        isMinimized = false;
    }

    public void StopVideo()
    {
        if (videoPlayer == null) return;

        videoPlayer.Stop();
    }


    // -------- HELPERS ----------
    private void RestoreOriginalLayout()
    {
        panelRect.anchorMin = originalAnchorMin;
        panelRect.anchorMax = originalAnchorMax;
        panelRect.offsetMin = originalOffsetMin;
        panelRect.offsetMax = originalOffsetMax;
        panelRect.sizeDelta = originalSize;
    }

    private void ResetLayout()
    {
        RestoreOriginalLayout();
        isFullscreen = false;
        isMinimized = false;
    }
}
