using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPostALPL.Context
{
    public static class Verifier
    {
        static readonly private int minCourriers = 1_000;
        static readonly private int maxCourriers = 50_000;

        static readonly private int minFeuilles = 1;
        static readonly private int maxFeuilles = 10;

        static readonly private List<short> typesFeuilles = new List<short>() {
            0, // Fine
            1, // Normale
            2 // Épaisse
        };

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
        /// Vérifie si les feuilles sont d'un type reconnu
        /// </summary>
        /// <param name="type">ID du type</param>
        /// <returns>VRAI si le type est reconnu</returns>
        static public bool TypeFeuille(short type)
        {
            return Verifier.typesFeuilles.Any(t => t == type);
        }
    }
}
