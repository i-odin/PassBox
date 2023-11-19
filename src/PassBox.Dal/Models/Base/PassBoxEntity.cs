using Common.Core.Models;

namespace PassBox.Dal.Models.Base;

public abstract class PassBoxEntity : Entity
{
    public string Name { get; set; }
}