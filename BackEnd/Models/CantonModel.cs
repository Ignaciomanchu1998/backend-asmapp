﻿namespace BackEnd.Models
{
    public class CantonModel
    {
        public int idCanton { get; set; }
        public ProvinciaModel? provincia { get; set; }
        public string? descripcion { get; set; }
        public bool estado { get; set; }
    }
}
