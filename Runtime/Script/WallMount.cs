using UdonSharp;
using UnityEngine;

namespace ControlPanel.Script
{
    public class WallMount : UdonSharpBehaviour
    {
        [SerializeField] private ControlPanel _controlPanel;

        public void ResetControlPanelPosition()
        {
            _controlPanel.transform.position = transform.forward * 0.11f;
        }
    }
}