using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Encre
{
    public int IdEncre { get; set; }

    public string? Nom { get; set; }

    public decimal? Prix { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
