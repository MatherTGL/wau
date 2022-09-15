using UnityEngine;

namespace ControlPlayer
{
    public interface IPlayerControl
    {
        void Initialization(in GameObject playerObject, in PlayerControlConfig playerControlConfig);
        void Move();
        void Rotation();
        void Zoom();
    }
}