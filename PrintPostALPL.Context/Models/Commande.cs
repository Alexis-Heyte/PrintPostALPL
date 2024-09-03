using System;
using System.Collections.Generic;

namespace PrintPostALPL.Context.Models;

public partial class Commande
{
    public int IdCommande { get; set; }

    public short? NbrCourriers { get; set; }

    public short? NbrFeuillets { get; set; }

    public DateTime? DateCreation { get; set; }

    public DateTime? DateDepotSouhaite { get; set; }

    public DateTime? DateDepotReel { get; set; }

    public decimal? MntDevise { get; set; }

    public decimal? MntFacture { get; set; }

    public int IdAffranchissement { get; set; }

    public int IdEnveloppe { get; set; }

    public int IdEncre { get; set; }

    public int IdFeuille { get; set; }

    public int IdClient { get; set; }

    public virtual Affranchissement IdAffranchissementNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Encre IdEncreNavigation { get; set; } = null!;

    public virtual Enveloppe IdEnveloppeNavigation { get; set; } = null!;

    public virtual Feuille IdFeuilleNavigation { get; set; } = null!;
}
