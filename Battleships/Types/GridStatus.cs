namespace Battleships;

public enum GridStatusType
{
    Untouched,
    Hit,
    Miss
}

internal struct GridStatus
{
    public GridStatusType Type = GridStatusType.Untouched;

    // Empty constructor is required.
    public GridStatus()
    {

    }

    public override string ToString()
    {
        switch (Type)
        {
            case GridStatusType.Untouched:
                return " ";
            case GridStatusType.Hit:
                return "X";
            case GridStatusType.Miss:
                return "-";
            default:
                throw new Exception($"unknown grid status type {Type}");
        }
    }
}

