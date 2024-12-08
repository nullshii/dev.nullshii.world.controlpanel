using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;

namespace ControlPanel.Script
{
    public sealed class ControlPanel : UdonSharpBehaviour
    {
        [field:SerializeField] public VRCPickup Pickup { get; private set; }
    }
}