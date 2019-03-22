using DapperExtensions.Mapper;
using u724.Core.Entities;

namespace u724.Core.Mapper
{
    public class GridDetailBtnModelMap : ClassMapper<GridDetailBtnModel>
    {
        public GridDetailBtnModelMap()
        {
            Table("HYGRID_GridDetailBtn");

            Map(f => f.BtnID).Key(KeyType.Assigned);

            AutoMap();
        }
    }
}
