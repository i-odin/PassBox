using Common.Core.Models;

namespace PassBox.Domain.Models.Base;

public abstract class PassBoxEntity : Entity
{
    public string Name { get; set; }
}