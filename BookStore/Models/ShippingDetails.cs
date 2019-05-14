using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Введите свой номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}