using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Feuille
{
    public int IdFeuille { get; set; }

    public string? Epaisseur { get; set; }

    public decimal? Prix { get; set; }

    public decimal? Poids { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
