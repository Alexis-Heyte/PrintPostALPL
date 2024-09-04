using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrintPostALPL.Context.Models;

namespace PrintPostALPL.Context
{
    public static class Verifier
    {
        static public PrintPostAlplContext DbContext { get; set; } = new PrintPostAlplContext();

        static readonly public int minCourriers = 1_000;
        static readonly public int maxCourriers = 50_000;

        static readonly public int minFeuilles = 1;
        static readonly public int maxFeuilles = 10;

        /// <summary>
        /// Vérifie le nombre de courriers demandé
        /// </summary>
        /// <param name="nb">Nombre de courriers</param>
        /// <returns>VRAI si le nombre est accepté</returns>
        static public bool NbCourriers(int nb)
        {
            return nb >= Verifier.minCourriers && nb <= Verifier.maxCourriers;
        }

        /// <summary>
        /// Vérifie le nombre de feuilles par courrier demandé
        /// </summary>
        /// <param name="nb">Nombre de feuilles par courrier</param>
        /// <returns>VRAI si le nombre de feuilles est accepté</returns>
        static public bool NbFeuillesParCourriers(int nb)
        {
            return nb >= Verifier.minFeuilles && nb <= Verifier.maxFeuilles;
        }

        /// <summary>
        /// Vérifie si les feuilles sont d'un type reconnu dans la base
        /// </summary>
        /// <param name="type">ID du type</param>
        /// <returns>VRAI si le type est reconnu</returns>
        static public bool TypeFeuille(int type)
        {
            var feuilles = DbContext.Feuilles.Where(m => m.IdFeuille == m.IdFeuille).ToList();
            return feuilles.Any(feuille => feuille.IdFeuille == type);
        }

        /// <summary>
        /// Vérifie si l'encre est d'un type reconnu dans la base
        /// </summary>
        /// <param name="type">ID de l'encre</param>
        /// <returns>VRAI si l'encre est reconnue</returns>
        static public bool TypeEncre(int type)
        {
            var encres = DbContext.Encres.Where(m => m.IdEncre == m.IdEncre).ToList();
            return encres.Any(encre => encre.IdEncre == type);
        }

        /// <summary>
        /// Vérifie si l'affranchissement est d'un type reconnu dans la base
        /// </summary>
        /// <param name="type">ID de l'affranchissement</param>
        /// <returns>VRAI si l'affranchissement est reconnu</returns>
        static public bool TypeAffranchissement(int type)
        {
            var affranchissements = DbContext.Affranchissements.Where(m => m.IdAffranchissement == m.IdAffranchissement).ToList();
            return affranchissements.Any(affranchissement => affranchissement.IdAffranchissement == type);
        }

        /// <summary>
        /// Vérifie si l'enveloppe est d'un type reconnu dans la base
        /// </summary>
        /// <param name="type">ID de l'enveloppe</param>
        /// <returns>VRAI si l'enveloppe est reconnue</returns>
        static public bool TypeEnveloppe(int type)
        {
            var enveloppes = DbContext.Enveloppes.Where(m => m.IdEnveloppe == m.IdEnveloppe).ToList();
            return enveloppes.Any(enveloppe => enveloppe.IdEnveloppe == type);
        }

        static public bool DateDepot(DateOnly date)
        {
            return DateDepot(date, DateOnly.FromDateTime(DateTime.Now));
        }

        static public bool DateDepot(DateOnly dateDepot, DateOnly dateDemande)
        {
            DateOnly dateLimite = dateDemande.AddDays(3);
            return dateDepot >= dateLimite;
        }
    }
}
