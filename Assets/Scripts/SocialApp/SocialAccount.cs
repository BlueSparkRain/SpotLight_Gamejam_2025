using UnityEngine;
using UnityEngine.UI;

public class SocialAccount : MonoBehaviour
{
    public E_SocialAccount account;
    Button accountButton;

    void Start()
    {
        accountButton=GetComponent<Button>();
        accountButton.onClick.AddListener(callBlog);
    }
    void Update()
    {


    }
    void callBlog() {
        SocialBlogCaller.Instance.CallBlog(account);
    }
}
