﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatiVerCore.Domain.Entities
{
    [Table("FomsLocalData")]
    public class LocalData
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("polis")]
        public string? Polis { get; set; }
        [Column("lastname")]
        public string? Lastname { get; set; }
        [Column("firstname")]
        public string? Firstname { get; set; }
        [Column("patronymic")]
        public string? Patronymic { get; set; }
        [Column("snils")]
        public string? Snils { get; set; }
        [Column("birthdate")]
        public string? Birthdate { get; set; }
        [Column("codemo")]
        public string? CodeMO { get; set; }
        [Column("begindate")]
        public string? BeginDate { get; set; }
        [Column("enddate")]
        public string? EndDate { get; set; }
    }
}