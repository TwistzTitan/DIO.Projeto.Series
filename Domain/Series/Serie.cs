
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DIO.Projeto.Series.Service;
using System.Diagnostics;
using DIO.Projeto.Series.Repository;
using System;

namespace DIO.Projeto.Series.Domain.Series
{
    public class Serie
    {
        [Index]
        public int SerieID {get; set;}
        [Required]
        public string SerieNome {get ; private set;}
        [Required]
        public string SerieDescricao {get; private set;}
        
        public string SerieURL {get ; private set;}

        public double SerieAvaliacao {get ; set;}

        public int TotalAvaliacao {get; set;}

        public int SerieStatus { get; private set; }
        
        [NotMapped]
        public SerieService serieService { 
            get { return serieService ?? new SerieService(new SerieRepositorio()); } 
            set { serieService = value; } 
        }
        [NotMapped]
        public bool TemURL { get { return !String.IsNullOrEmpty(SerieURL); } private set { }  }
        public Serie(string nome,string desc, string url)
        {
            
            this.SerieNome = nome;
            this.SerieDescricao = desc;
            this.SerieURL = url;
            this.SerieStatus = 1;
        }
        
    
    }
}