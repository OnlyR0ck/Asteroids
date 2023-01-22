using System.Collections.Generic;
using UnityEngine;

namespace Zenject.ReflectionBaking
{
    public class ZenjectReflectionBakingSettings : ScriptableObject
    {
        [SerializeField]
        bool _isEnabledInBuilds = true;

        [SerializeField]
        bool _isEnabledInEditor = false;

        [SerializeField]
        bool _allGeneratedAssemblies = true;

        [SerializeField]
        List<string> _includeAssemblies = null;

        [SerializeField]
        List<string> _excludeAssemblies = null;

        [SerializeField]
        List<string> _namespacePatterns = null;

        public List<string> NamespacePatterns => _namespacePatterns;

        public List<string> IncludeAssemblies => _includeAssemblies;

        public List<string> ExcludeAssemblies => _excludeAssemblies;

        public bool IsEnabledInEditor => _isEnabledInEditor;

        public bool IsEnabledInBuilds => _isEnabledInBuilds;

        public bool AllGeneratedAssemblies => _allGeneratedAssemblies;
    }
}
