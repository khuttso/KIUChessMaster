using KIUChessMaster.Domain.Common;

namespace KIUChessMaster.Domain.Entities;

public class Player : BaseEntity<Guid>
{ 
    public Guid UserId { get; set; } // FK - References User.UserID
    public string Username { get; set; }
    public FideTitle FideTitle { get; set; }
    public KiuTitle KiuTitle { get; set; }
    public decimal KiuRating { get; set; }
    public decimal? FideRating { get; set; }
    public string? FideProfileLink { get; set; }
    public ChessLevel? ChessLevel { get; set; }

    public Player()
    {
        IsActive = true;
        IsDeleted = false;
        CreatedDate = DateTime.UtcNow;
    }

    public Player(
        Guid id,
        Guid userId,
        string username,
        FideTitle fideTitle,
        KiuTitle kiuTitle,
        decimal kiuRating,
        decimal? fideRating,
        string? fideProfileLink) : this()
    {
        Id = id;
        UserId = userId;
        Username = username;
        FideTitle = fideTitle;
        KiuTitle = kiuTitle;
        KiuRating = kiuRating;
        FideRating = fideRating;
        FideProfileLink = fideProfileLink;
    }
}