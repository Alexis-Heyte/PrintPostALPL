using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Affranchissement
{
    public int IdAffranchissement { get; set; }

    public string? Nom { get; set; }

    public decimal? Prix20gOuMoins { get; set; }

    public decimal? PrixPlus20g { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
