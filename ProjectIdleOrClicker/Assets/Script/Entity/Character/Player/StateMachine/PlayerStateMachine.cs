public class PlayerStateMachine : StateMachine
{
    public Player player;

    public PlayerProgressingState ProgressingState;
    public PlayerBattleState BattleState;
    public PlayerSkillState SkillState;
    public PlayerPositioningState PositioningState;

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        ProgressingState = new PlayerProgressingState(this);
        BattleState = new PlayerBattleState(this);
        SkillState = new PlayerSkillState(this);
        PositioningState = new PlayerPositioningState(this);

        ChangeState(ProgressingState);

        player.TimeCheckEvent += FixedUpdate;
    }
}
