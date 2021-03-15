namespace DiscordRPG
{
    public enum State
    {
        Idle,
        Begin_battle,
        Pre_player_turn,
        Player_turn,

        Use_item,

        Check_bp,
        Awaiting_bp,

        Get_single_target,
        Attacking_one,

        Enemy_turn,
        Awaiting_enemy,

        Dead,

        Returning_home,
        Home,

        Prepare_to_go_out,
        Going_out

    }
}
