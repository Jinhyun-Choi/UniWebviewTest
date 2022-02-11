using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public static class Extension_
{
    public static string ToJson<T>(this T value)
    {

        var json = JsonConvert.SerializeObject(value, Formatting.Indented);
        return json;
    }
}

public class WebviewTest : MonoBehaviour
{
    [SerializeField] private RectTransform webViewRect;
    [SerializeField] private Button button;
    [SerializeField] private UniWebView webView;
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        webView.OnMessageReceived += ReceiveMessage;
        button.onClick.AddListener(OpenWebView);
    }

    private void OpenWebView()
    {
        webView.ReferenceRectTransform = webViewRect;
        webView.Load("https://docs.uniwebview.com/game.html");
        webView.Show();
    }

    private void ReceiveMessage(UniWebView view, UniWebViewMessage message)
    {
        text.text = message.ToJson();
        Debug.LogError(message.ToJson());
    }
}
