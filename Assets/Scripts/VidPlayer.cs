using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private string videoFileName;

    private void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
