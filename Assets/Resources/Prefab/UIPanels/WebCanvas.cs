using DG.Tweening;
using System.Collections;
using UnityEngine;
public class WebCanvas : BasePanel
{
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        transform.DOMove(Vector3.zero, 1);
        yield return null;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {
        throw new System.NotImplementedException();
    }

    protected override void Init()
    {
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
