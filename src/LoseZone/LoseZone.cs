using Godot;
using System;

public partial class LoseZone : Node3D
{
    [Signal]
    public delegate void BeatEnteredLoseZoneEventHandler();
    private void OnLoseZoneAreaEnter(Area3D area)
    {
        if (area.IsInGroup("Beat"))
        {
            EmitSignal(nameof(BeatEnteredLoseZone));
        }
    }
}
