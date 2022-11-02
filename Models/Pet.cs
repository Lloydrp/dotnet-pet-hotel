using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType
    {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever,
        Pug,
    }

    public enum PetColorType
    {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted,
        Fawn,
    }

    public class Pet
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required, JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed { get; set; }

        [Required, JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }

        public DateTime? checkedInAt { get; set; }

        public PetOwner petOwner { get; set; }

        [ForeignKey("PetOwners")]
        public int petOwnerid { get; set; }

        public void checkIn()
        {
            this.checkedInAt = DateTime.Now;
        }

        public void checkOut()
        {
            this.checkedInAt = null;
        }
    }
}
