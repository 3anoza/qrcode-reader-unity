using UnityEngine;
using UnityEngine.UI;


namespace Assets.Mobile.Scripts
{
    public class MetaInfoHandler : MonoBehaviour
    {
        private GameObject _qrCodeMetaInfo;

        public void SetQrCodeMetaInfo(GameObject metaInfoPrefab)
        {
            _qrCodeMetaInfo = metaInfoPrefab;
        }

        public void ShowQrCodeContent(string meta)
        {
            _qrCodeMetaInfo.transform.Find("Preview").gameObject.SetActive(true);
            _qrCodeMetaInfo.transform.Find("Preview/LinkButton/Text").GetComponent<Text>().text = meta;
        }

        public void ShowQrCodeContent(string meta, GameObject model)
        {
            ShowQrCodeContent(meta);
        }
    }
}
