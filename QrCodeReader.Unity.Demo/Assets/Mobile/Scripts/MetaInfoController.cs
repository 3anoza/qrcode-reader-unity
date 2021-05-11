using QRFoundation;
using UnityEngine;
using UnityEngine.Events;


namespace Assets.Mobile.Scripts
{
    public class MetaInfoController : MonoBehaviour
    {

        public UnityEvent OnLinkOpened = new UnityEvent();
        public UnityEvent OnMetaInfoClosed = new UnityEvent();

        public void OnLinkButtonClick()
        {
            OnLinkOpened.Invoke();
        }

        public void OnCloseButtonClick()
        {
            gameObject.transform.Find("Preview").gameObject.SetActive(false);
            OnMetaInfoClosed.Invoke();
        }
    }
}