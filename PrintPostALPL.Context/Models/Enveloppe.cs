using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Enveloppe
{
    public int IdEnveloppe { get; set; }

    public string? Taille { get; set; }

    public bool? Logo { get; set; }

    public decimal? Prix { get; set; }

    public decimal? Poids { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
