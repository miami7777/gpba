using System.ComponentModel.DataAnnotations;


namespace Core.DTO.Request
{
    public class AddOfferRequest
    {        
        [DataType(DataType.Text)]
        public string Brand { get; set; }
       
        [DataType(DataType.Text)]
        public string Model { get; set; }
        public int SupplierId { get; set; }        
    }
}
