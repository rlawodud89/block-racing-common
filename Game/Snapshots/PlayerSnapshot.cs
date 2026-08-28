using block_racing_common.Game.Enums;

namespace block_racing_common.Game.Snapshots
{
    public class PlayerSnapshot
    {
        public long Id { get; }

        public int CarX { get; }

        public float Distance { get; }

        public float Speed { get; }

        public bool IsStunned { get; }

        public PlayMode Mode { get; }

        public PieceType? CurrentPieceType { get; }

        public Rotation? CurrentPieceRotation { get; }

        public float ShootCooldownRemaining { get; }

        public LaneSnapshot Lane { get; }

        
        public PlayerSnapshot(long id, int carX, float distance,
            float speed, bool isStunned, PlayMode mode, PieceType? currentPieceType,
            Rotation? currentPieceRotation, float shootCooldownRemaining,
            LaneSnapshot lane)
        {
            Id = id;

            CarX = carX;

            Distance = distance;

            Speed = speed;

            IsStunned = isStunned;

            Mode = mode;

            CurrentPieceType = currentPieceType;

            CurrentPieceRotation = currentPieceRotation;

            ShootCooldownRemaining = shootCooldownRemaining;

            Lane = lane;
        }
    }
}
