using AutoMapper;
using Fast.Core.DTOs;
using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fast.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            AddProfileEntityToDto("Fast.Core.Entities", "Fast.Core.DTOs", "Dto");
            AddProfileDtoToEntity("Fast.Core.Entities", "Fast.Core.DTOs", "Dto");
            CreateMap<UsuarioSignUp, Usuario>();

        }


        internal void AddProfileEntityToDto(string namespaceEntity, string namespaceDto, string remove)
        {

            var match = getTypes(namespaceEntity, namespaceDto, remove);

            foreach (var item in match)
            {
                CreateMap(item.Key, item.Value);
            }

        }

        internal void AddProfileDtoToEntity(string namespaceEntity, string namespaceDto, string remove)
        {
            var match = getTypes(namespaceDto, namespaceEntity, remove);

            foreach (var item in match)
            {
                CreateMap(item.Key, item.Value);
            }

        }


        private Dictionary<Type, Type> getTypes(string key, string value, string remove)
        {
            var typesKeys = GetNamespacesInAssembly(key);

            var typesValue = GetNamespacesInAssembly(value);

            Dictionary<Type, Type> match = new Dictionary<Type, Type>();

            foreach (var item in typesKeys)
            {
                foreach (var valu in typesValue)
                {
                    if (item.Name.Replace(remove, "") == valu.Name.Replace(remove, ""))
                    {
                        match.Add(item, valu);
                        break;
                    }
                }


            }

            return match;

        }

        private static IEnumerable<Type> GetNamespacesInAssembly(string namespaces)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("LPH"));
            List<Type> types = new List<Type>();
            foreach (var item in assemblies)
            {
                foreach (var t in item.GetTypes())
                {
                    if (t.Namespace == namespaces)
                    {
                        types.Add(t);
                    }
                }
            }

            return types;




        }

    }
}
