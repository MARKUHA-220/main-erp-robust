using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared.Standing;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
public sealed partial class StandingStateComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField]
    public SoundSpecifier DownSound { get; private set; } = new SoundCollectionSpecifier("BodyFall");

    // Corvax edit start
    [DataField, AutoNetworkedField, ViewVariables(VVAccess.ReadWrite)]
    public StandingState CurrentState { get; set; } = StandingState.Standing;
    // Corvax edit end

    public bool Standing
    {
        get => CurrentState == StandingState.Standing;
        set => CurrentState = value ? StandingState.Standing : StandingState.Lying;
    }

    /// <summary>
    ///     List of fixtures that had their collision mask changed when the entity was downed.
    ///     Required for re-adding the collision mask.
    /// </summary>
    [DataField, AutoNetworkedField]
    public List<string> ChangedFixtures = new();
}
// Corvax edit start
public enum StandingState
{
    Lying,
    GettingUp,
    Standing,
}
// Corvax edit end
