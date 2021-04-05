using System;
using System.Collections.Generic;

#nullable disable

namespace DIO.Projeto.Series
{
    public partial class Series
    {
        public int SerieId { get; set; }
        public string SerieNome { get; set; }
        public string SerieDescricao { get; set; }
        public string SerieUrl { get; set; }
        public double SerieAvaliacao { get; set; }
        public int TotalAvaliacao { get; set; }
        public int SerieStatus { get; set; }
    }
}
