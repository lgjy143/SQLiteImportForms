using DapperExtensions.Mapper;
using u724.Core.Entities;

namespace u724.Core.Mapper
{
    public class GridInfoModelMapper : ClassMapper<GridInfoModel>
    {
        public GridInfoModelMapper()
        {
            Table("HYGRID_GridInfo");

            Map(f => f.Auid).Key(KeyType.Assigned);

            AutoMap();
        }
    }
}
