namespace KIUChessMaster.Domain.Common;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }

    public void SetUpdated() => UpdatedDate = DateTime.UtcNow;
}