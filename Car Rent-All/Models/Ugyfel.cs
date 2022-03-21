using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    [Table("Ugyfelek")]
    public class Ugyfel
    {
        [Key, Required]
        public int Id { get; set; }

        [Display(Name = "Név:")]
        [Required(ErrorMessage = "A név megadása kötelező!"), MaxLength(60), Column(TypeName = "VARCHAR")]
        public string Nev { get; set; }

        [Display(Name = "Cím:")]
        [Required(ErrorMessage = "A cím megadása kötelező!"), MaxLength(200), Column(TypeName = "VARCHAR")]
        public string Cim { get; set; }

        [Display(Name = "Születési dátum:")]
        public DateTime? SzuletesiDatum { get; set; }

        [Display(Name = "Jogosítvány azonosító:")]
        [Required(ErrorMessage = "Az azonosító okmány számának megadása kötelező!")]
        public string Jogositvany { get; set; }

        [Display(Name = "Telefonszám:")]
        [Phone(ErrorMessage = "A megadott telefonszám nem egy érvényes telefonszám!")]
        [Required(ErrorMessage = "A telefonszám megadása kötelező!"), Column(TypeName = "VARCHAR")]
        public string Telefonszam { get; set; }

        [Display(Name = "E-mail cím:")]
        [EmailAddress(ErrorMessage = "A megadott e-mail cím nem egy érvényes e-mail cím!")]
        [Required(ErrorMessage = "Az e-mail cím megadása kötelező!"), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
    }
}