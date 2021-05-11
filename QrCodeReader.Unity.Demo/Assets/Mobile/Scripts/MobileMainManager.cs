using QRFoundation;
using UnityEngine;


namespace Assets.Mobile.Scripts
{
    public class MobileMainManager : MonoBehaviour
    {
        #region Injections
        [SerializeField]
#pragma warning disable 649
        private GameObject _cameraObject;
        [SerializeField]
        private GameObject _houseModelPrefab;
        [SerializeField]
        private GameObject _metaInfoPrefab;
#pragma warning restore 649
        #endregion


        private QRCodeTracker _qrCodeTracker;
        private MetaInfoHandler _metaInfoHandler;

        private const float QR_CODE_WIDTH = 0.21f;
        
        #region Mono behaviour pipeline

        private void Start()
        {
            InitRefs();
        }

        #endregion

        #region Initialization

        private void InitRefs()
        {
            _qrCodeTracker = _cameraObject.AddComponent<QRCodeTracker>();
            _qrCodeTracker.prefab = _houseModelPrefab;
            _qrCodeTracker.codeWidth = QR_CODE_WIDTH;
            _qrCodeTracker.debugMode = false;

            var metaInfo = Instantiate(_metaInfoPrefab);
            metaInfo.GetComponent<MetaInfoController>().OnMetaInfoClosed.AddListener(OnMetaInfoClosedHandler);
            _metaInfoHandler = _cameraObject.AddComponent<MetaInfoHandler>();
            _metaInfoHandler.SetQrCodeMetaInfo(metaInfo);

            _qrCodeTracker.onCodeDetected.AddListener(_metaInfoHandler.ShowQrCodeContent);
            _qrCodeTracker.onCodeRegistered.AddListener(_metaInfoHandler.ShowQrCodeContent);
#if UNITY_EDITOR
            _metaInfoHandler.ShowQrCodeContent($"{_metaInfoHandler.GetInstanceID()}_{_metaInfoHandler.GetHashCode()}");
#endif
        }

        #endregion

        public void OnMetaInfoClosedHandler()
        {
            _qrCodeTracker.Unregister(TrackingState.Searching);
        }
    }
}