using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Siret { get; set; }

    public string? Email { get; set; }

    public string? RaisonSocial { get; set; }

    public decimal? MntPenalite { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
