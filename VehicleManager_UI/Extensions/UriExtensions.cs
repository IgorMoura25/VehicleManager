using System;
using System.Linq;

namespace VehicleManager_UI.Extensions
{
    /// <summary>
    /// Classe responsável por extender métodos da classe <seealso cref="Uri"/>.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Combina vários caminhos relativos em uma única <seealso cref="Uri"/>.
        /// </summary>
        /// <param name="uri">Uri a ser combinada.</param>
        /// <param name="paths">Caminhos relativos a serem inseridos na Uri.</param>
        /// <returns>A URI combinada.</returns>
        public static Uri Combine(this Uri uri, params string[] paths)
        {
            return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) => string.Format("{0}/{1}", current.TrimEnd('/'), path.TrimStart('/'))));
        }
    }
}
