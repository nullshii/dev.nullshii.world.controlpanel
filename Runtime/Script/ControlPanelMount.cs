using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace ControlPanel.Script
{   
    public sealed class ControlPanelMount : UdonSharpBehaviour
    {
        [SerializeField] private ControlPanel _controlPanel;
        [SerializeField] private Transform _respawnTransform;

        public void RespawnAndRemountControlPanel()
        {
            if (_controlPanel == null) return;
            if (_respawnTransform == null) return;
            
            Networking.SetOwner(Networking.LocalPlayer, _controlPanel.gameObject);
            _controlPanel.Pickup.Drop();
            
            _respawnTransform.GetPositionAndRotation(out Vector3 position, out Quaternion rotation);
            _controlPanel.transform.SetPositionAndRotation(position, rotation);
        }
    }
}