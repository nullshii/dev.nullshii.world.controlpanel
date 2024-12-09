using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace ControlPanel.Script
{   
    public sealed class ControlPanelMount : UdonSharpBehaviour
    {
        [SerializeField] private ControlPanel _controlPanel;
        [SerializeField] private Transform _respawnTransform;
        [SerializeField] private float _lerpDelta = 0.05f;
        [SerializeField] private float _minimumDistanceToEnd = 0.05f;
        [SerializeField] [HideInInspector] private bool _isRespawning;
        
        public void RespawnAndRemountControlPanel()
        {
            if (_controlPanel == null) return;
            if (_respawnTransform == null) return;
                
            Networking.SetOwner(Networking.LocalPlayer, _controlPanel.gameObject);
            _controlPanel.Pickup.Drop();

            _isRespawning = true;
        }

        public void DebugRespawnAndRemountControlPanel()
        {
            if (_controlPanel == null) return;
            if (_respawnTransform == null) return;
            
            Networking.SetOwner(Networking.LocalPlayer, _controlPanel.gameObject);
            _controlPanel.Pickup.Drop();
            
            _respawnTransform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
            _controlPanel.transform.SetPositionAndRotation(position, rotation);
        }

        private void Update()
        {
            if (!_isRespawning) return;

            if (_controlPanel.Pickup.IsHeld)
            {
                _controlPanel.Pickup.Drop();
            }
            
            Transform panelTransform = _controlPanel.transform;
            
            panelTransform.position = Vector3.Lerp(panelTransform.position, _respawnTransform.position, _lerpDelta);
            panelTransform.rotation = Quaternion.Lerp(panelTransform.rotation, _respawnTransform.rotation, _lerpDelta);

            if (Vector3.Distance(panelTransform.position, _respawnTransform.position) < _minimumDistanceToEnd
                && Quaternion.Angle(panelTransform.rotation, _respawnTransform.rotation) < _minimumDistanceToEnd)
            {
                _isRespawning = false;
            }
        }
    }
}