namespace DiscordRPG
{
    public enum State
    {
        Idle,

        Begin_battle,
        Pre_player_turn,
        Player_turn,

        Check_bp,
        Awaiting_bp,
        Use_bp,

        Bp_get_multiple_targets,
        Awaiting_bp_enemies,

        Get_single_target,
        Attacking_one,
        Attacking_multiple,

        Use_item,

        Enemy_turn,
        Awaiting_enemy,

        Battle_over,

        Dead,

        Returning_home,
        Home,

        Prepare_to_go_out,
        Going_out

    }
}
