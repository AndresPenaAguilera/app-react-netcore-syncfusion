using Models.DTO;

namespace Interfaces.Domain
{
    public  interface IDataTransformation
    {
        List<OrderDTO> ExtractDataFromJson(string json);
    }
}
