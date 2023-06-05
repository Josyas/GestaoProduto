using CitelTeste.Data;
using CitelTeste.Mappings;
using CitelTeste.Repository;
using CitelTeste.Repository.Interface;
using CitelTeste.Service;
using CitelTeste.Service.Interface;

namespace CitelTeste.DependenciesExtension
{
    public static class DependenciesExtension
    {
        public static void AddMySqlConnection(this IServiceCollection services)
        {
            services.AddScoped<ConexaoDB>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddAutoMapper(typeof(EntitiesToDTOProfile));
            services.AddCors();
        }
    }
}
