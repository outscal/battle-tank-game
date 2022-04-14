using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    public static class NamingExtensions
    {
        public static string GetAssociatedAssetPath(this SubstanceGraph graph, string name, string extension)
        {
            var fileName = Path.GetFileNameWithoutExtension(graph.FilePath);
            return Path.Combine(graph.OutputPath, $"{fileName}_{name}.{extension}");
        }

        public static string GetAssetFileName(this SubstanceGraph graph)
        {
            return Path.GetFileNameWithoutExtension(graph.FilePath);
        }
    }
}