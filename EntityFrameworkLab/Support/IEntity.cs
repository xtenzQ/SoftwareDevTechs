using System.Collections.Generic;

namespace EntityFrameworkLab.Support
{
    public interface IEntity
    {
        int Id { set; get; }
        void Insert();
        void Update();
        List<IEntity> Load();
    }
}