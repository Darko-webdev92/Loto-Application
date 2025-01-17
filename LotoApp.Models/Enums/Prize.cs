using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.Enums
{
    public enum Prize
    {
        [Display(Name = "50 Dollars")]
        _50_Dollars = 3,
        [Display(Name = "100 Dollars")]
        _100_Dollars,
        TV,
        Vocation,
        Car
    }
}
