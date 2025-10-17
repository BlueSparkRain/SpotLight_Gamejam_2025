using UnityEngine;
public enum E_SocialAccount {
    People1, 
    People2,
    People3, 
    People4,
}

public class SocialBlogCaller : MonoSingleton<SocialBlogCaller>
{
    public Transform accountsContainer;
    public GameObject blog1Prefab;
    public GameObject blog2Prefab;
    public GameObject blog3Prefab;
    void Start()
    {

    }

    void Update()
    {

    }

    public void CallBlog(E_SocialAccount account) {
        Transform newBlog;
        switch (account)
        {
            case E_SocialAccount.People1:
                newBlog = Instantiate(blog1Prefab).transform;
                break;
            case E_SocialAccount.People2:
                newBlog = Instantiate(blog2Prefab).transform;
                break;
            case E_SocialAccount.People3:
                newBlog = Instantiate(blog3Prefab).transform;
                break;
            //case E_SocialAccount.People4:
            //    newBlog = Instantiate(blogPrefab).transform;
            //    break;
            default:
                newBlog = Instantiate(blog1Prefab).transform;
                break;
        }
        newBlog.SetParent(accountsContainer);

    }


}
