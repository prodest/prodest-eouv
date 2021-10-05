using AutoMapper;
using System;
using System.Collections.Generic;

namespace Prodest.EOuv.Shared.Configuracao
{
    public static class AutoMapperUtil
    {
        public static IEnumerable<Type> GetAutoMapperProfilesFromAllAssemblies()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var aType in assembly.GetTypes())
                {
                    if (aType.IsClass && !aType.IsAbstract && aType.IsSubclassOf(typeof(Profile)))
                        yield return aType;
                }
            }
        }
    }
}