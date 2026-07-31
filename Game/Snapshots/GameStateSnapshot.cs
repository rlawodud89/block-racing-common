using System.Collections.Generic;

namespace block_racing_common.Game.Snapshots
{
    public class GameStateSnapshot
    {
        public long Tick { get; }

        public int TargetDistance { get; }

        public IReadOnlyList<PlayerSnapshot> Players { get; }


        public GameStateSnapshot(long tick, int targetDistance, IReadOnlyList<PlayerSnapshot> players)
        {
            Tick = tick;
            TargetDistance = targetDistance;
            Players = players;
        }
    }
}