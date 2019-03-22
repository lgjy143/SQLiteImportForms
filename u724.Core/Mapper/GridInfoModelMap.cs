using DapperExtensions.Mapper;
using u724.Core.Entities;

namespace u724.Core.Mapper
{
    public class GridInfoModelMap : ClassMapper<GridInfoModel>
    {
        public GridInfoModelMap()
        {
            Table("HYGRID_GridInfo");

            Map(f => f.Auid).Key(KeyType.Assigned);

            AutoMap();
        }
    }
}
