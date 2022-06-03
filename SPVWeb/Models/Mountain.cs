﻿using System.ComponentModel.DataAnnotations;

namespace SPVWeb.Models
{
    public class Mountain
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 30)]
        public int TrackCount { get; set; }
        [Range (1,100)]
        [RegularExpression(@"^\d+\,\d{0,2}$")]
        public decimal SkiLiftRent { get; set; }
        [Range(1, 100)]
        [RegularExpression(@"^\d+\,\d{0,2}$")]
        public decimal HelmetRent { get; set; }
        [RegularExpression(@"^\d+\,\d{0,2}$")]
        public decimal SkiiRent { get; set; } 


        public string Description { get; set; } = "";

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}