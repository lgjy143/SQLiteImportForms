using DapperExtensions.Mapper;
using u724.Core.Entities;

namespace u724.Core.Mapper
{
    public class GridFieldModelMap : ClassMapper<GridFieldModel>
    {
        public GridFieldModelMap()
        {
            Table("HYGRID_GridField");

            Map(f => f.FieldID).Key(KeyType.Assigned);

            AutoMap();
        }
    }
}
