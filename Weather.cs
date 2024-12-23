namespace Clima.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public double Temperatura { get; set; }
        public int Umidade { get; set; }
        public int Pressao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}