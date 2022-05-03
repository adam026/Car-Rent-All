using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    [Table("Jarmuvek")]
    public class Jarmu
    {
        [Key, Required]
        public int Id { get; set; }

        [Display(Name = "A jármű neve:")]
        [Required(ErrorMessage = "A jármű nevének megadása kötelező")]
        public string Nev { get; set; }

        [Display(Name = "A jármű rendszáma:")]
        [Required(ErrorMessage = "A jármű rendszámának megadása kötelező!")]
        public string Rendszam { get; set; }

        [Display(Name = "A jármű alvázszáma:")]
        [Required(ErrorMessage = "A jármű alvázszámának megadása kötelező!")]
        public string Alvazszam { get; set; }

        [Display(Name = "A jármű váltójának típusa: ")]
        [Required(ErrorMessage = "A jármű váltójának kiválasztása kötelező!")]
        public int valtoId { get; set; }
        public Valto Valto { get; set; }

        [Display(Name = "A jármű üzemanyagának típusa:")]
        [Required(ErrorMessage = "A jármű üzemanyagának kiválasztása kötelező!")]
        public int UzemanyagId { get; set; }
        public Uzemanyag Uzemanyag { get; set; }

        [Display(Name = "Az ülések/férőhelyek száma:")]
        [Required(ErrorMessage = "Az ülések/férőhelyek számának megadása kötelező!")]
        public int Ules { get; set; }

        [Display(Name = "Az ajtók száma:")]
        [Required(ErrorMessage = "Az ajtók számának megadása kötelező!")]
        public int Ajtok { get; set; }

        [Display(Name = "A gyártás éve: ")]
        [Required(ErrorMessage = "A gyártás évének megadása kötelező!")]
        public int GyartasEve { get; set; }

        [Display(Name = "Kép: ")]
        public string Kep { get; set; }

        [Display(Name = "Készlet: ")]
        [Required(ErrorMessage = "A készlet megadása kötelező!")]
        [Range(1,20)]
        public int Keszlet { get; set; }

        public int Elerheto { get; set; }

        [Display(Name = "Bérlés ára/nap: ")]
        [Required(ErrorMessage = "A napi ár megadása kötelező!")]
        public int Ar { get; set; }
    }
}