
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DIO.Projeto.Series.Service;
using System.Diagnostics;
using DIO.Projeto.Series.Repository;

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

        public double SerieAvaliacao {get ; private set;}

        public int TotalAvaliacao {get; private set;}
        
        [NotMapped]
        public SerieService serieService { 
            get { return serieService ?? new SerieService(new SerieRepositorio()); } 
            set { serieService = value; } 
        }
        
        public Serie(string nome,string desc, string url)
        {
            
            this.SerieNome = nome;
            this.SerieDescricao = desc;
            this.SerieURL = url;
            
        }
        
        public void AvaliarSerie(double av)
        {
            Debug.Assert(!av.Equals(null) && (av > 0 && av < 10));
            
            serieService.AvaliarSerie(this, av);
            
        }   
        
    
    
    
    }
}