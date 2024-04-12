namespace DerbyCountyAPI.Dto
{
    public class StringDTO
    {

        public string Data { get; set; }


        public StringDTO(string body)
        {
            Data = body;
        }
    }
}
